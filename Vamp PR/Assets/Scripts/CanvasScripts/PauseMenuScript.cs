using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{

    public GameObject pauseCanvas;

    private bool isPaused;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused) Unpause();
            else Pause();
        }
    }

    void Start()
    {
        Unpause();
    }

    private void Pause()
    {
        Time.timeScale = 0.0f;
        pauseCanvas.SetActive(true);
    }

    private void Unpause()
    {
        Time.timeScale = 1.0f;
        pauseCanvas.SetActive(false);
    }

    public void LoadScene(int sceneIndex)
    {
        LevelLoader.instance.LoadScene(sceneIndex);
    }

    public void ResumeGameButton()
    {
        Unpause();
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1.0f;
        LevelLoader.instance.LoadScene(0);
    }
}
