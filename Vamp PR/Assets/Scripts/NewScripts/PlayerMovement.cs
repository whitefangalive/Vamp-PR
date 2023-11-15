using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpHeight = 5f;
    public float fallSpeed = 10f; // New variable for fall speed
    public float jumpSpeed = 7f; // New variable for jump speed
    public float currentSpeed { get; private set; }

    private Rigidbody2D rb;
    public bool isGrounded;
    private float jumpStartTime;
    private float timeToReachApex;

    private bool isDead;

    // Audio
    private AudioManager playerAudio;

    void Awake()
    {
        playerAudio = GetComponent<AudioManager>();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timeToReachApex = CalculateTimeToReachApex();
        currentSpeed = moveSpeed;
    }

    private void Update()
    {
        // Check if the player is grounded
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, LayerMask.GetMask("ground"));

        // Handle player input
        HandleInput();
    }

    private void FixedUpdate()
    {
        // Move the player
        MovePlayer();
    }

    private void HandleInput()
    {
        // Horizontal movement
        Vector2 movement = new Vector2(isDead ? 0.0f : 1.0f, 0f);
        Debug.Log(movement);

        // Jumping
        if ((Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) && isGrounded)
        {
            Jump();
        }

        // Apply movement
        rb.velocity = new Vector2(movement.x * currentSpeed, rb.velocity.y);

        // Update the current speed
        currentSpeed = Mathf.Abs(rb.velocity.x);
    }

    public void Die()
    {
        isDead = true;
    }

    public void Undie()
    {
        isDead = false;
    }

    private void Jump()
    {
        jumpStartTime = Time.time;
        float jumpVelocity = CalculateJumpVelocity();

        if (playerAudio != null) {
            playerAudio.Play("Jump");
        }

        // Set the vertical velocity for a jump
        rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
    }

    private void MovePlayer()
    {
        // Handle falling by applying additional gravity when not grounded
        if (!isGrounded)
        {
            rb.velocity += Vector2.down * fallSpeed * Time.fixedDeltaTime;
        }
    }

    private float CalculateJumpVelocity()
    {
        // Calculate the initial vertical velocity for a given jump height and time to reach the apex
        float gravity = Mathf.Abs(Physics2D.gravity.y);
        float jumpVelocity = Mathf.Sqrt(2 * gravity * jumpHeight);

        return jumpVelocity;
    }

    private float CalculateTimeToReachApex()
    {
        // Calculate the time it takes for the player to reach the apex of the jump
        float gravity = Mathf.Abs(Physics2D.gravity.y);
        float timeToReachApex = Mathf.Sqrt(2 * jumpHeight / gravity);

        return timeToReachApex;
    }
}
