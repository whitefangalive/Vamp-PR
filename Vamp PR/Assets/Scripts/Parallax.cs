using UnityEngine;

public class Parallax : MonoBehaviour
{
    private GameObject player;
    public float depth = 1;

    public ParallaxEffectSpeedMultiplierVector speedVector;

    private float foregroundSpeedMultiplier = 1f;
    private float midgroundSpeedMultiplier = 0.5f;
    private float backgroundSpeedMultiplier = 0.2f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        backgroundSpeedMultiplier = speedVector.vector.x;
        midgroundSpeedMultiplier = speedVector.vector.y;
        foregroundSpeedMultiplier = speedVector.vector.z;
    }

    private void Update()
    {
        backgroundSpeedMultiplier = speedVector.vector.x;
        midgroundSpeedMultiplier = speedVector.vector.y;
        foregroundSpeedMultiplier = speedVector.vector.z;
        if (player != null)
        {
            // Get the player's current speed
            float playerSpeed = player.GetComponent<PlayerMovement>().currentSpeed;

            // Calculate the movement based on player speed and depth
            float parallaxSpeed = CalculateParallaxSpeed(depth, playerSpeed);
            float movement = -parallaxSpeed * Time.deltaTime;

            // Update the object's position
            transform.position += new Vector3(movement, 0f, 0f);
        }
    }

    private float CalculateParallaxSpeed(float depth, float playerSpeed)
    {
        float parallaxSpeed = 0f;

        // Set speed based on depth
        switch (depth)
        {
            case 0:
                parallaxSpeed = playerSpeed * foregroundSpeedMultiplier;
                break;
            case 1:
                parallaxSpeed = playerSpeed * midgroundSpeedMultiplier;
                break;
            case 2:
                parallaxSpeed = playerSpeed * backgroundSpeedMultiplier;
                break;
            default:
                break;
        }

        return parallaxSpeed;
    }
}
