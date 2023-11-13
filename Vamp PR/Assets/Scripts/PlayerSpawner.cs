using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{

    public GameObject playerDeathCanvas;

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

    void Start()
    {
        playerDeathCanvas.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hazard"))
        {
            PlayerDeath();
        }
        
    }

    public void PlayerDeath()
    {
        playerDeathCanvas.SetActive(true);
        playerAudio.Play("Death");
        sr.enabled = false;
        playerMovement.Die();
    }

    public void SpawnPlayer()
    {
        Debug.Log("Called here!");
        // transform.position = new Vector3(0.0f, 3.046875f, 0.0f);
        Time.timeScale = 1.0f;
        sr.enabled = true;
        playerMovement.Undie();
        playerDeathCanvas.SetActive(false);
    }
}
