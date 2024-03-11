using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // Adjust the speed as needed
    public float jumpForce = 10f; // Adjust the jump force as needed

    private Rigidbody2D rb;
    private bool isGrounded;
    private Transform groundCheck;
    private LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("GroundCheck"); // Create an empty GameObject at player's feet for ground check
        groundLayer = LayerMask.GetMask("Ground"); // Create a "Ground" layer in Unity and assign it to the objects player should stand on
    }

    void Update()
    {
        HandleInput();
        CheckGrounded();
    }

    void HandleInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput, 0f);
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void CheckGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
