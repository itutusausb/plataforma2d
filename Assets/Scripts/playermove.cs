using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playermove : MonoBehaviour
{
    public float runSpeed = 2;
    public float jumpSpeed = 3;
    public float doubleJumpSpeed = 2.5f;
    private bool canDoubleJump;

    Rigidbody2D rigidbody2D;

    public bool betterJump = false;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public Animator animatorhit;

    public GameObject DustLeft;
    public GameObject DustRight;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey("space"))
        {
            if (CheckGround.isGrounded)
            {
                canDoubleJump = true;
                rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpSpeed);
            }
            else
            {
                if (Input.GetKeyDown("space"))
                {
                    if (canDoubleJump)
                    {
                        animator.SetBool("DoubleJump", true);
                        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, doubleJumpSpeed);
                        canDoubleJump = false;
                    }
                }
            }

        }


        if (CheckGround.isGrounded == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }
        if (CheckGround.isGrounded == true)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("DoubleJump", false);
            animator.SetBool("Falling", false);
        }

        if (rigidbody2D.velocity.y < 0)
        {
            animator.SetBool("Falling", true);

        }
        else if (rigidbody2D.velocity.y > 0)

            animator.SetBool("Falling", false);
    }




    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayerKeyboard();
    }

    public void MovePlayerKeyboard()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rigidbody2D.velocity = new Vector2(runSpeed, rigidbody2D.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);

            if (CheckGround.isGrounded == true)
            {

                DustLeft.SetActive(true);
                DustRight.SetActive(false);
            }
            

        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rigidbody2D.velocity = new Vector2(-runSpeed, rigidbody2D.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);

            if (CheckGround.isGrounded == true)
            {

                DustLeft.SetActive(false);
                DustRight.SetActive(true);
            }
        }
        else
        {
            rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
            animator.SetBool("Run", false);

            DustLeft.SetActive(false);
            DustRight.SetActive(false);
        }

        if (betterJump)
        {
            if (rigidbody2D.velocity.y < 0)
            {
                rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }
            if (rigidbody2D.velocity.y > 0 && !Input.GetKey("space"))
            {
                rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }
        }
    }


}

