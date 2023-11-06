using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Player.GetComponent<playerController>().currentSpeed * Time.deltaTime;
        transform.position += new Vector3(delta, 0f, 0f);
    }
}
