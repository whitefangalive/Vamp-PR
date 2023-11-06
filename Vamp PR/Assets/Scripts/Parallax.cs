using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Parallax : MonoBehaviour
{
    private GameObject Player;
    public float depth = 1;
    private float delta = 0;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            delta = Player.GetComponent<playerController>().currentSpeed * Time.deltaTime;
            transform.position += new Vector3(delta * depth, 0f, 0f);
        }
    }
}
