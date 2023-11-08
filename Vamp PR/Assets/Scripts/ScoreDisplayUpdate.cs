using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayUpdate : MonoBehaviour
{
    private GameObject scoreKeeper;
    int score = 0;
    public TMP_Text messageText;
    // Start is called before the first frame update
    void Start()
    {
        scoreKeeper = GameObject.FindGameObjectWithTag("ScoreKeeper");
        messageText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score = scoreKeeper.GetComponent<Score>().score;
        messageText.SetText(score.ToString());
    }
}
