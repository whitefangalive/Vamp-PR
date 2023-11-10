using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    public GameObject backgroundPrefab;
    public Transform player;
    public float spawnInterval = 2.0f;
    public float spawnOffset = 10.0f; // How far ahead of the player to spawn obstacles
    public float despawnOffset = 20.0f;

    private float nextSpawnTime;

    private void Start()
    {
        // Initialize the next spawn time.
        nextSpawnTime = Time.time + spawnInterval;
    }

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            // Calculate the position to spawn the obstacle.
            if (player == null) return;
            Vector3 spawnPosition = new Vector3(player.position.x + spawnOffset, 0, 0);

            // Spawn the obstacle at the calculated position.
            Instantiate(backgroundPrefab, spawnPosition, Quaternion.identity);

            // Update the next spawn time.
            nextSpawnTime = Time.time + spawnInterval;
        }

        // Remove obstacles that have moved far enough behind the player
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Background");
        foreach (GameObject obstacle in obstacles)
        {
            if (obstacle.transform.position.x < player.position.x - despawnOffset)
            {
                Destroy(obstacle);
            }
        }
    }
}
