using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Configuration parameters
    [Header("Player")]
    [SerializeField] int health = 200;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 0.5f;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip shootSound;
    [Range(0, 1)] [SerializeField] float shootSoundVolume = 0.25f;
    [Range(0, 1)] [SerializeField] float deathSoundVolume = 0.25f;
    [Header("Projectile")]
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 0.3f;
    [SerializeField] GameObject laserPrefab;

    Coroutine firingCoroutine;

    float xMin;
    float xMax;
    float yMin;
    float yMax;
    
    void Start()
    {
        SetUpMoveBoundaries();
    }

    void Update()
    {
        Move();
        Fire();
    }

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }

        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
            yield return new WaitForSeconds(projectileFiringPeriod);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();

        if (!damageDealer) { return; }
        
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();

        damageDealer.Hit();

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        FindObjectOfType<Level>().LoadGameOver();
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;

        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;

    }
    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newXPos = Mathf.Clamp( transform.position.x + deltaX,xMin,xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY,yMin,yMax);

        transform.position = new Vector2(newXPos,newYPos);
    }

    //ViewPortToWorldPoint()
    //------------------------------------------------------
    //Convert the position of someting as it relates to
    //the camera view, into a world space value
    //Top Left (0,1), Top Right (1,1)
    //Bottom Left (0,0), Bottom Right (1,0)

    //Coroutine
    //---------------------------------------------------------------------------------------
    //A method which can suspend(otherwise known as yield)
    //its execution untill the yield instructions you gave it are met Example
    //-When player gets to zero health, start the KillPlayer coroutine:
    //--Trigger death animation
    //--Yield(wait) for 3 seconds (death animation takes 3 seconds)
    //--Restart Level

    //Keywords Used in a Coroutine
    //-----------------------------------------------------------------------------------
    //StartCoroutine(NameOfCoroutine())         <==Call Coroutine somewhere //ex. KillPlayer
    //IEnumerator NameOfCoroutine()             <==IEnumerator return type 
    //{
    //  //Things to do
    //  yield return SomeCondition              <== yield(wait) return untill someting is met eg. yield return new WaitForSeconds(3)
    //  //Things to do
    //)
}
