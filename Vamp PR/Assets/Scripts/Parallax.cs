using UnityEngine;

public class Parallax : MonoBehaviour
{
    private GameObject player;
    public float depth = 1;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (player != null)
        {
            // Get the player's current speed
            float playerSpeed = player.GetComponent<playerController>().currentSpeed;

            // Calculate the movement based on player speed and depth
            float movement = -playerSpeed * Time.deltaTime * (1 / depth);

            // Update the object's position
            transform.position += new Vector3(movement, 0f, 0f);
        }
    }
}
