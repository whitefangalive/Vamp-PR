using UnityEngine;
using System.Collections.Generic; // Import the namespace for Lists

public class ObstacleSpawner : MonoBehaviour
{
    public List<GameObject> obstaclePrefabs; // Serialized list of obstacle prefabs
    public Transform player;
    public float spawnInterval = 2.0f;
    public Vector3 spawnOffset; // How far ahead of the player to spawn obstacles
    public float despawnOffset = 20.0f;

    private float nextSpawnTime;

    private void Start()
    {
        // Initialize the next spawn time.
        nextSpawnTime = Time.time + spawnInterval;
    }

    private void Update()
    {
        if (player == null) return;
        if (Time.time >= nextSpawnTime)
        {
            // Calculate the position to spawn the obstacle.
            Vector3 spawnPosition = new Vector3(player.position.x + spawnOffset.x, spawnOffset.y, spawnOffset.z);

            // Randomly select an obstacle prefab from the list
            GameObject selectedObstacle = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)];

            // Spawn the selected obstacle at the calculated position.
            Instantiate(selectedObstacle, spawnPosition, Quaternion.identity);

            // Update the next spawn time.
            nextSpawnTime = Time.time + spawnInterval;
        }

        // Remove obstacles that have moved far enough behind the player
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Hazard");
        foreach (GameObject obstacle in obstacles)
        {
            if (obstacle.transform.position.x < player.position.x - despawnOffset)
            {
                Destroy(obstacle);
            }
        }
    }
}
