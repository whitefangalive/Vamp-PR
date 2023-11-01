using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCanvas : MonoBehaviour
{
    public void PlayButtonPressed()
    {
        LevelLoader.instance.LoadScene(1);
    }
}
