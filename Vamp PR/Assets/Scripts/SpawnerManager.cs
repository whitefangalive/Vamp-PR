using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    
    public Transform player;
    public List<GameObject> spawnerList;

    private float nextSpawnDistance;

    void Start()
    {
        // Initialize the next spawn distance.
        ActivateSpawners();
        nextSpawnDistance = player.position.x + GetAverageSpawnDistanceInterval();
    }

    private void Update()
    {
        if (player == null) return;

        // Check if the player has traveled far enough to spawn a new object
        if (player.position.x >= nextSpawnDistance)
        {
            ActivateSpawners();
        }
    }

    private void ActivateSpawners()
    {

        float coinToss = Random.value;

        // Special Condition: Old man collectable
        if (coinToss < 0.2f)
        {
            SpawnGivenObjectFromSpawner("CollectableSpawner", "oldManCrossing");
            SpawnGivenObjectFromSpawner(spawnerName: "TownSpawner");
            SpawnGivenObjectFromSpawner(spawnerName: "NPCSpawner");

        }
        else
        {
            NormalConditionSpawn();
        }
        

        // Update the next spawn distance.
        nextSpawnDistance += GetAverageSpawnDistanceInterval();
    }

    private void NormalConditionSpawn()
    {
        foreach(GameObject spawner in spawnerList)
        {
            if(spawner.name != "ChunkSpawner")
            {
                SpawnGivenObjectFromSpawner(spawnerName: spawner.name);
            }
        }
    }

    private void SpawnGivenObjectFromSpawner(string spawnerName="default", string objectName="default")
    {

        // The spawner to activate
        GameObject spawner;

        if (spawnerName == "default")
        {
            spawner = GetRandomSpawner();
        }
        else 
        {
            // Find the spawner with the specified name
            spawner = spawnerList.Find(s => s.name == spawnerName);
        }

        // Check if the spawner is found
        if (spawner != null)
        {
            // Spawn the object from the spawner with the specified name
            spawner.GetComponent<ObjectSpawner>().SpawnObject(objectName);
        }
        else
        {
            Debug.LogError("Spawner not found: " + spawnerName);
        }
    }

    private GameObject GetRandomSpawner()
    {
        // Randomly select an object prefab from the list
        return spawnerList[Random.Range(0, spawnerList.Count)];
    }

    private float GetAverageSpawnDistanceInterval()
    {
        if (spawnerList.Count == 0)
        {
            Debug.LogError("No ObjectSpawners in the spawnerList.");
            return 0f;
        }

        float totalSpawnDistanceInterval = 0f;

        foreach (GameObject spawner in spawnerList)
        {
            totalSpawnDistanceInterval += spawner.GetComponent<ObjectSpawner>().spawnDistanceInterval;
        }

        // Calculate and return the average spawn distance interval.
        return totalSpawnDistanceInterval / spawnerList.Count;
    }

}