using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private float horizontal;
    public float speed = 3f;
    private float jumpPower = 16f;
    private bool isFacingRight = true;
    public int totalJumps;
    public float gravity = -10f;
    public float gravityScale = 1;
    private Vector3 platformVelocity;

    const float groundCheckRadius = 0.2f;
    bool isGrounded = false;

    public MovingPlatform currentPlatform; // Dodaj nowe pole dla obiektu MovingPlatform
    [SerializeField] private Transform groundCheckPos; // Zmieñ nazwê pola na groundCheckPos


    public Animator animator;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;



    void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        horizontal = Input.GetAxisRaw("Horizontal");


        animator.SetFloat("yVelocity", rb.velocity.y);

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            Jump();

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

        }
        else
        {
            transform.parent = null;

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

            rb.velocity = Vector2.up * Mathf.Sqrt(jumpPower * -2f * (gravity * gravityScale));
        }

    }

}