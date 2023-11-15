using UnityEngine;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour
{
    public List<GameObject> objectPrefabs; // Serialized list of object prefabs
    public string objectTag;
    public Transform player;
    public float spawnDistanceInterval = 5.0f; // Distance between object spawns
    public Vector3 spawnOffset; // How far ahead of the player to spawn objects
    public float despawnOffset = 20.0f;

    private float nextSpawnDistance;
    private bool allowSpawn = true; // Flag to control spawning

    private void Start()
    {
        // Initialize the next spawn distance.
        SpawnObject();
        nextSpawnDistance = player.position.x + spawnDistanceInterval;
    }

    private void Update()
    {
        if (player == null) return;

        // Check if the player has traveled far enough to spawn a new object
        if (allowSpawn && player.position.x >= nextSpawnDistance)
        {
            SpawnObject();
        }

        DespawnObject();
    }

    public void ToggleSpawn(bool allow)
    {
        allowSpawn = allow;
    }

    public void SpawnObject(string objectName = "default", string ignore = "default")
    {
        if (!allowSpawn)
        {
            Debug.Log("Spawn is not allowed.");
            return;
        }

        GameObject selectedObject;

        if (objectName != "default")
        {
            selectedObject = objectPrefabs.Find(s => s.name == objectName);
        }
        else if (ignore != "default")
        {
            selectedObject = null;
            while (selectedObject.name != ignore)
            {
                selectedObject = objectPrefabs.Find(s => s.name == objectName);
            }
        }
        else
        {
            selectedObject = objectPrefabs[Random.Range(0, objectPrefabs.Count)];
        }

        // Calculate the position to spawn the object.
        float randomXOffset = Random.Range(-5f, 5f); // Adjust the range as needed
        Vector3 spawnPosition = new Vector3(player.position.x + spawnOffset.x + randomXOffset, spawnOffset.y, spawnOffset.z);

        // Spawn the selected object at the calculated position, setting the parent to this transform
        GameObject instantiatedObject = Instantiate(selectedObject, spawnPosition, Quaternion.identity, transform);

        nextSpawnDistance = player.position.x + spawnDistanceInterval;
    }

    private void DespawnObject()
    {
        // Remove objects that have moved far enough behind the player
        GameObject[] objects = GameObject.FindGameObjectsWithTag(objectTag);
        foreach (GameObject obj in objects)
        {
            if (obj.transform.position.x < player.position.x - despawnOffset)
            {
                Destroy(obj);
            }
        }
    }
}
