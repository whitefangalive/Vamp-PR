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

    private void Start()
    {
        // Initialize the next spawn distance.
        // SpawnObject();
        nextSpawnDistance = player.position.x + spawnDistanceInterval;
    }

    private void Update()
    {
        if (player == null) return;
        DespawnObject();
    }

    public void SpawnObject(string objectName="default", string ignore="default")
    {

        GameObject selectedObject;

        if (objectName != "default")
        {
            selectedObject = objectPrefabs.Find(s => s.name == objectName);
        }
        else if (ignore != "default")
        {
            selectedObject = null;
            while(selectedObject.name != ignore)
            {
                selectedObject = objectPrefabs.Find(s => s.name == objectName);
            }
        }
        else 
        {
            selectedObject = objectPrefabs[Random.Range(0, objectPrefabs.Count)];
        }
    
        // Calculate the position to spawn the object.
        float randomXOffset = Random.Range(-10f, 10f); // Adjust the range as needed
        Vector3 spawnPosition = new Vector3(player.position.x + spawnOffset.x + randomXOffset, spawnOffset.y, spawnOffset.z);

        // Spawn the selected object at the calculated position, setting the parent to this transform
        GameObject instantiatedObject = Instantiate(selectedObject, spawnPosition, Quaternion.identity, transform);
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
