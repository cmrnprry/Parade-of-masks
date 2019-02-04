using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool facingRight;
    public float maxSpeed = 5f;

    private SpriteRenderer sr;

    //force player will jump
    public float jumpForce = 1000f;

    //this variable will tell if our player is grounded or not
    private bool isGrounded;

    //checks to see if the mask is up or not
    public bool isMask;
    // the current speed of the player
    public float speed;

    //how long before the player starts to slow down
    private float counterSlow;
    public float countSlow;

    //how long before the player starts to speed up
    private float counterSpeed;
    public float countSpeed;

    public float knockback;
    public float knockbackLength;
    public float knockbackCount;
    public bool knockFromRight;
    public bool isKnocked = false;

    private Rigidbody2D rb2d;
    private Animator ani;


    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();

        speed = maxSpeed;
        counterSlow = countSlow;
        counterSpeed = countSpeed;

        isMask = false;
        facingRight = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            isGrounded = true;
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            isGrounded = false;
            ani.SetBool("Jump", false);
        }
    }

    public void isMaskUp()
    {
        if (speed > 1)
        {

            if (isMask && counterSlow < 0)
            {
                speed -= 1;
                counterSlow = countSlow;
                counterSpeed = countSpeed;
            }

        }

        if (speed < maxSpeed)
        {
            if (!isMask && counterSpeed < 0)
            {
                speed += 1;
            }

        }

    }

    public void Knockback()
    {
        if (knockbackCount > 0)
        {
            if (!knockFromRight)
            {
                //knock to the left
                rb2d.AddForce(new Vector2(-knockback, knockback * 2), ForceMode2D.Force);
            }
            else
            {
                rb2d.AddForce(new Vector2(knockback, knockback * 2), ForceMode2D.Force);
            }

            knockbackCount -= Time.deltaTime;
        }
        else
        {
            isKnocked = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if we hold the "X" key
        if (Input.GetKey(KeyCode.X))
        {
            isMask = true;
            ani.SetBool("isMaskOn", true);
            isMaskUp();
        }
        else
        {
            isMask = false;
            ani.SetBool("isMaskOn", false);
            isMaskUp();
        }

        if (isKnocked)
        {
            Knockback();
        }
    }


    // do physics in FixedUpdate
    void FixedUpdate()
    {
        if (isMask)
        {
            counterSlow -= Time.deltaTime;
        }
        else
        {
            counterSpeed -= Time.deltaTime;
        }


        float h = Input.GetAxis("Horizontal");

        // checks if you are going too fast
        if (knockbackCount <= 0)
        {
            if (h > 0)
            {
                rb2d.velocity = new Vector2(h * speed, rb2d.velocity.y);
                ani.SetFloat("Speed", speed);
            }
            else if (h < 0)
            {
                rb2d.velocity = new Vector2(h * speed, rb2d.velocity.y);
                ani.SetFloat("Speed", speed);
            }
            else
            {
                rb2d.velocity = new Vector2(0, rb2d.velocity.y);
                ani.SetFloat("Speed", 0f);
            }
        }

        //we check if isGrounded is true and we pressed Space button
        if (isGrounded == true && Input.GetKey(KeyCode.Space))
        {
            ani.SetBool("Jump", true);
            rb2d.AddForce(new Vector2(0f, jumpForce));
        }

        if (h > 0 && !facingRight)
        {
            Flip();

        }
        else if (h < 0 && facingRight)
        {
            Flip();
        }

    }

    // Changes the way the character is facing by negating X
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}