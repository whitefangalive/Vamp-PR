using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private PlayerSpawner playerSpawner;

    void Awake()
    {
        playerSpawner = gameObject.GetComponent<PlayerSpawner>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hazard"))
        {
            // Debug.Log("Die");
            playerSpawner.PlayerDeath();
            Destroy(gameObject);
            // PlayerSpawner.SpawnPlayer();
        }
        
    }
}
