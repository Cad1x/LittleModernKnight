using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 3f;
    private float jumpPower = 16f;
    private bool isFacingRight = true;
    bool monsterjump;
    public int totalJumps;
    int availableJumps;
    public float gravity = -5f;
    public float gravityScale = 1;
    bool multipleJump;
    bool monsterJump;


    const float groundCheckRadius = 0.2f;
    bool isGrounded = false;

    public Animator animator;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    IEnumerator MonsterJumpDelay()
    {
        monsterJump = true;
        yield return new WaitForSeconds(0.2f);
        monsterJump = false;
    }

    void Awake()
    {
        availableJumps = totalJumps;

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal")); 
        horizontal = Input.GetAxisRaw("Horizontal");

        //if (Input.GetKey(KeyCode.Space) && (isGrounded=false))
        //{
        //    rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        //}
animator.SetFloat("yVelocity", rb.velocity.y);

        if (Input.GetKey(KeyCode.UpArrow))
            Jump();

        
        //if (Input.GetKey(KeyCode.UpArrow) && rb.velocity.y > 0f)
        //{
        //    rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        //}
        


        Flip();

    }


    void GroundCheck()
    {
        bool wasGrounded = isGrounded;
        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckRadius, groundLayer);
        if (colliders.Length > 0)
        {
            isGrounded = true;

            animator.SetBool("isJumping", !isGrounded);
            if (!wasGrounded)
            {
                availableJumps = totalJumps;
                multipleJump = false;

                //AudioManager.instance.PlaySFX("landing");
            }


            
        }
        else
        {
            //Un-parent the transform
            transform.parent = null;

            if (wasGrounded)
                StartCoroutine(MonsterJumpDelay());
        }
    } 

    private void FixedUpdate()
    {
        GroundCheck();
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }


    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }


    void Jump()
    {
        if (isGrounded)
        {
            multipleJump = true;
            availableJumps--;

            rb.velocity = Vector2.up * Mathf.Sqrt(jumpPower * -2f * (gravity * gravityScale));
        }
        else
        {
            if (monsterJump)
            {
                multipleJump = true;
                availableJumps--;

                rb.velocity = Vector2.up * jumpPower;
            }

            if (multipleJump && availableJumps > 0)
            {
                availableJumps--;

                rb.velocity = Vector2.up * jumpPower;
            }
        }
    }

}