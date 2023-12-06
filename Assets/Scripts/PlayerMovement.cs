using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private bool moveLeft = false;
    private bool moveRight = false;
    public float jumpForce = 5;
    bool grounded;
    private float horizontalMove;
    public float speed = 5;
    public Animator animator;
    
    public float KBForce;
    public float KBCount;
    public float KBTotalTime;

    public bool KnockFromRight;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void PointerDownLeft()
    {
        moveLeft = true;
    }

    public void PointerUpLeft()
    {
        moveLeft = false;
    }

    public void PointerDownRight()
    {
        moveRight = true;
    }

    public void PointerUpRight()
    {
        moveRight = false;
    }

    void Update()
    {
        MovePlayer();
        
    }

    private void MovePlayer()
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (KBCount<=0) 
        {
            if (moveLeft)
            {
                horizontalMove = -speed;
                sr.flipX = true;
            }
            else if (moveRight)
            {
                horizontalMove = speed;
                sr.flipX = false;
            }
            else
            {
                horizontalMove = 0;
            }
        }
        else
        {
            if (KnockFromRight == true)
            { 
                rb.velocity = new Vector2(-KBForce,KBForce);
            }
            if (KnockFromRight == false)
            {
                rb.velocity = new Vector2(KBForce, KBForce);
            }

            KBCount -= Time.deltaTime;

        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
    
    public void Jump()
    {
        if (grounded)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
    }
}
