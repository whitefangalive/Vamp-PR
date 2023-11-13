using UnityEngine;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour
{
    public List<GameObject> obstaclePrefabs; // Serialized list of obstacle prefabs
    public Transform player;
    public float spawnDistanceInterval = 5.0f; // Distance between obstacle spawns
    public Vector3 spawnOffset; // How far ahead of the player to spawn obstacles
    public float despawnOffset = 20.0f;

    private float nextSpawnDistance;

    private void Start()
    {
        // Initialize the next spawn distance.
        nextSpawnDistance = player.position.x + spawnDistanceInterval;
    }

    private void Update()
    {
        if (player == null) return;

        // Check if the player has traveled far enough to spawn a new obstacle
        if (player.position.x >= nextSpawnDistance)
        {
            // Calculate the position to spawn the obstacle.
            Vector3 spawnPosition = new Vector3(player.position.x + spawnOffset.x, spawnOffset.y, spawnOffset.z);

            // Randomly select an obstacle prefab from the list
            GameObject selectedObstacle = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)];

            // Spawn the selected obstacle at the calculated position.
            Instantiate(selectedObstacle, spawnPosition, Quaternion.identity);

            // Update the next spawn distance.
            nextSpawnDistance += spawnDistanceInterval;
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
