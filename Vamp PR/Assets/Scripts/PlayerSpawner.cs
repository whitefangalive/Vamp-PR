using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{

    public GameObject playerDeathCanvas;

    void Start()
    {
        playerDeathCanvas.SetActive(false);
    }

    public void PlayerDeath()
    {
        // Time.timeScale = 0.0f;
        playerDeathCanvas.SetActive(true);
    }

    public void SpawnPlayer()
    {
        Time.timeScale = 1.0f;
    }
}
