using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
    private AudioManager sceneAudio;

    void Awake()
    {
        sceneAudio = GetComponentInChildren<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        sceneAudio.Play("Music");
    }

}
