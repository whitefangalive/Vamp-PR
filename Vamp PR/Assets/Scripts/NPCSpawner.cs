using UnityEngine;
using System.Collections.Generic;

public class NPCSpawner : MonoBehaviour
{
    public List<GameObject> npcPrefabs;
    public Transform player;
    public float spawnDistanceInterval = 5.0f; // Distance between NPC spawns
    public Vector3 spawnOffset;
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

        // Check if the player has traveled far enough to spawn a new NPC
        if (player.position.x >= nextSpawnDistance)
        {
            // Calculate the position to spawn the NPC.
            Vector3 spawnPosition = new Vector3(player.position.x + spawnOffset.x, spawnOffset.y, spawnOffset.z);

            // Randomly select an NPC prefab from the list
            GameObject selectedNPC = npcPrefabs[Random.Range(0, npcPrefabs.Count)];

            // Spawn the selected NPC at the calculated position.
            Instantiate(selectedNPC, spawnPosition, Quaternion.identity);

            // Update the next spawn distance.
            nextSpawnDistance += spawnDistanceInterval;
        }

        // Remove NPCs that have moved far enough behind the player
        GameObject[] npcs = GameObject.FindGameObjectsWithTag("NPC");
        foreach (GameObject npc in npcs)
        {
            if (npc.transform.position.x < player.position.x - despawnOffset)
            {
                Destroy(npc);
            }
        }
    }
}
