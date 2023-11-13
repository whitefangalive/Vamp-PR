using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private PlayerSpawner playerSpawner;
    private SpriteRenderer sr;
    private AudioManager playerAudio;

    private PlayerMovement playerMovement;

    void Awake()
    {
        playerSpawner =GetComponent<PlayerSpawner>();
        sr = GetComponentInChildren<SpriteRenderer>();
        playerAudio = GetComponent<AudioManager>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hazard"))
        {
            // Debug.Log("Die");
            playerSpawner.PlayerDeath();
            // Destroy(gameObject);
            playerAudio.Play("Death");
            sr.enabled = false;
            // playerMovement.enabled = false;
            playerMovement.Die();
            // PlayerSpawner.SpawnPlayer();
        }
        
    }
}
