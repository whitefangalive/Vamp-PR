using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{

    private LevelLoader levelLoader;

    private void Awake()
    {
        levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
    }

    public void LoadScene(int sceneIndex)
    {
        levelLoader.LoadScene(sceneIndex);
    }
}
