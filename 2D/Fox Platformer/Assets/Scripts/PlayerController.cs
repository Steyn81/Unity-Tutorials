using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 7.5f;
    [SerializeField] Rigidbody2D rb;
    
    void Start()
    {
        
    }


    void Update()
    {
        rb.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), rb.velocity.y);
    }
}
