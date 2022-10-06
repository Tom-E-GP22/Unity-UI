using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMove : MonoBehaviour
{
    [HideInInspector] public bool fighting = false;

    [HideInInspector] public bool grounded = true;
    bool doubleJump = true;
    float speed = 5f;

    SpriteRenderer sr;
    Animator animationController;
    Rigidbody2D rb2d;

    void Start()
    {
        animationController = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float horizontalMove = Input.GetAxis("Horizontal") * speed;
        float verticalMove = Input.GetAxis("Jump");
    
        animationController.SetFloat("Speed", Mathf.Abs(horizontalMove));
        
        if(Input.GetButtonDown("Jump") && (grounded || doubleJump) && !fighting)
        {   
            if(!grounded)
                doubleJump = false;
            
            rb2d.velocity = new Vector2(rb2d.velocity.x, 5);
            animationController.SetTrigger("Jump");
        }

        animationController.SetFloat("AirSpeedY", rb2d.velocity.y);

        if(rb2d.velocity.x < 0)
            sr.flipX = true;
        else if(rb2d.velocity.x > 0)
            sr.flipX = false;

        Vector2 movement = new Vector2(horizontalMove, rb2d.velocity.y);
        if(!fighting)
            rb2d.velocity = movement;

        /*if(Input.GetButtonUp("shift") && !fighting && grounded)
        {
            rb2d.velocity = new Vector2(5, rb2d.velocity.y);
            animationController.SetTrigger("Roll");
        }*/
    }

    void OnCollisionEnter2D(Collision2D collide)
    {
        if(collide.gameObject.CompareTag("Ground"))
        {
            animationController.SetBool("Grounded", true);
            doubleJump = true;
            grounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collide)
    {
        if(collide.gameObject.CompareTag("Ground"))
        {
            animationController.SetBool("Grounded", false);
            grounded = false;
        }
    }
}
