using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveJoystick : MonoBehaviour
{
    private float horizontalMove = 0f;
    private float verticalMove = 0f;
    public Joystick joystick;
    private float runSpeedHorizontal = 2;

    public float runSpeed = 1.25f;
    public float jumpSpeed = 3;
    public float doubleJumpSpeed = 2.5f;
    private bool canDoubleJump;

    Rigidbody2D rigidbody2D;

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
        if (horizontalMove>0)
        {
            //rigidbody2D.velocity = new Vector2(runSpeed, rigidbody2D.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);

        }
        else if (horizontalMove<0)
        {
            //rigidbody2D.velocity = new Vector2(-runSpeed, rigidbody2D.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);
        }
        else
        {
            //rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
            animator.SetBool("Run", false);
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
        horizontalMove = joystick.Horizontal * runSpeedHorizontal;
        transform.position += new Vector3(horizontalMove, 0, 0) * Time.deltaTime * runSpeed;

        

    }

    public void Jump()
    {
        if (CheckGround.isGrounded)
        {
            canDoubleJump = true;
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpSpeed);
        }
        else
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
