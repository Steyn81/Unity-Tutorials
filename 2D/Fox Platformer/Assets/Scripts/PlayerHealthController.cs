using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;

    public int currentHealth;

    [SerializeField] float invincibleLength;
    public int maxHealth;

    private float invincibleCounter;
    private SpriteRenderer sr;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (invincibleCounter > 0)
        {
            invincibleCounter -= Time.deltaTime; //count down timer

            if (invincibleCounter <= 0)
            {
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
            }
        }
    }

    public void DealDamage()
    {
        if (invincibleCounter <= 0)
        {
            currentHealth--;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                //gameObject.SetActive(false);

                LevelManager.instance.RespawnPlayer();
            }
            else
            {
                invincibleCounter = invincibleLength;
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f);

                PlayerController.instance.KnockBack();
            }

            UIController.instance.UpdateHealthDisplay();
        }

    }
}
