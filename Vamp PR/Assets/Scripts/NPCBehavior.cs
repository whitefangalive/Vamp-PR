using UnityEngine;

public class NPCBehavior : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool isWalking = false;
    private float timeSinceLastAction = 0f;
    private float timeToIdle = 3f; // Default time to idle
    private float walkSpeed = 2f; // Default walking speed

    private AudioManager audioManager;

    void Awake()
    {
        audioManager = GetComponent<AudioManager>();
    }

    private void Start()
    {
        // Get the Animator component attached to the NPC GameObject
        animator = GetComponent<Animator>();

        // Get the Rigidbody2D component attached to the NPC GameObject
        rb = GetComponent<Rigidbody2D>();

        // Get the SpriteRenderer component attached to the NPC GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Randomize the initial walk speed and duration
        RandomizeWalkParameters();

        // Start in the idle state
        SetIdleState();
    }

    private void Update()
    {
        // Update the timer
        timeSinceLastAction += Time.deltaTime;

        // Check if it's time to switch between walking and standing still
        if (timeSinceLastAction >= timeToIdle)
        {
            // Toggle between walking and standing still
            ToggleState();
        }
    }

    private void ToggleState()
    {
        // Reset the timer
        timeSinceLastAction = 0f;

        // Randomize walk parameters
        RandomizeWalkParameters();

        // Toggle between walking and standing still
        if (isWalking)
        {
            SetIdleState();
        }
        else
        {
            SetWalkingState();
        }
    }

    private void SetWalkingState()
    {
        // Set the Animator parameter to trigger the walking animation
        animator.SetBool("IsWalking", true);
        isWalking = true;

        // Determine the direction to move (left or right)
        float randomDirection = Random.Range(0f, 1f);
        if (randomDirection < 0.5f)
        {
            // Move left
            rb.velocity = new Vector2(-walkSpeed, 0f);
            // Flip the SpriteRenderer to face left
            spriteRenderer.flipX = true;
        }
        else
        {
            // Move right
            rb.velocity = new Vector2(walkSpeed, 0f);
            // Make sure the SpriteRenderer is facing right
            spriteRenderer.flipX = false;
        }
    }

    private void SetIdleState()
    {
        // Set the Animator parameter to trigger the idle animation
        animator.SetBool("IsWalking", false);
        isWalking = false;

        // Stop the NPC from moving
        rb.velocity = Vector2.zero;
    }

    private void RandomizeWalkParameters()
    {
        // Randomize walk speed and time to idle
        walkSpeed = Random.Range(1f, 3f); // Adjust min and max values as needed
        timeToIdle = Random.Range(2f, 6f); // Adjust min and max values as needed
    }

    public void OnPlayerPassed()
    {
        // Generate a random value to determine whether to play the sound
        float randomValue = Random.value;

        // Adjust this threshold to control the probability of playing the sound
        float soundProbability = 0.3f;

        if (randomValue < soundProbability)
        {
            // Play the sound only if the random value is below the threshold
            audioManager.Play("Dialogue");
        }
    }
}
