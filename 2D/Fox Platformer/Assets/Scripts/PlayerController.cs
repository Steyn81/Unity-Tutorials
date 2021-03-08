using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 7.5f;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float jumpForce;
    [SerializeField] Transform groundCheckPoint;
    [SerializeField] LayerMask whatIsGround;

    private bool isGrounded;
    private bool canDoubleJump;

    private Animator anim;
    private SpriteRenderer sr;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        rb.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), rb.velocity.y); //GetAxisRaw - stop movement immediately

        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position,.2f,whatIsGround);

        if(isGrounded)
        {
            canDoubleJump = true;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            else
            {
                if(canDoubleJump)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    canDoubleJump = false;
                }
            }
            
        }

        if(rb.velocity.x < 0)
        { 
            sr.flipX = true; 
        }
        else if(rb.velocity.x > 0)
        {
            sr.flipX = false;
        }

        anim.SetFloat("moveSpeed", Mathf.Abs(rb.velocity.x)); //always returns a positive number
        anim.SetBool("isGrounded", isGrounded);
    }
}
