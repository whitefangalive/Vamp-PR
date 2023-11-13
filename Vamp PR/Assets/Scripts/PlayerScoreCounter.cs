using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerScoreCounter : MonoBehaviour
{

    public int playerScore;
    public GameObject scoreCanvas;
    public GameObject gainPointsPrefab;

    private TMP_Text scoreText;
    private Transform gainedPointsParent;

    public int minValue = 57;
    public int maxValue = 101;
    public float lowProbability = 0.8f;

    // private int 

    void Awake()
    {
        scoreText = scoreCanvas.transform.Find("Score").gameObject.GetComponent<TMP_Text>();
        gainedPointsParent = scoreCanvas.transform.Find("GainPointsParent");
    }

    void Start()
    {
        UpdateScoreText();
    }

    public void DodgeObstacle(Sprite icon, int points)
    {
        AddPoints(points);
        StartCoroutine(DisplayGainedPoints(points, icon));
        UpdateScoreText();
    }

    public void AddPoints(int pointsAmount=10)
    {
        playerScore+=pointsAmount;
    }

    public IEnumerator DisplayGainedPoints(int points, Sprite icon)
    {
        GameObject newPointsObject = Instantiate(gainPointsPrefab, gainedPointsParent.position, Quaternion.identity);
        newPointsObject.transform.SetParent(gainedPointsParent);
        newPointsObject.transform.Find("Text").gameObject.GetComponent<TMP_Text>().text = $"+{points}";
        newPointsObject.transform.Find("Icon").gameObject.GetComponent<Image>().sprite = icon;

        yield return new WaitForSeconds(2.0f);

        Destroy(newPointsObject);


    }

    // public void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.CompareTag("ObstacleDodgedTrigger"))
    //     {
    //         playerScore+=GenerateRandomNumber();
    //         UpdateScoreText();
    //     }
    // }

    private int GenerateRandomNumber()
    {
        float randomValue = Random.value;

        // Apply probability distribution
        if (randomValue < lowProbability)
        {
            // Generate a low number with higher probability
            return Random.Range(minValue, (minValue + maxValue) / 2 + 1);
        }
        else
        {
            // Generate a high number with lower probability
            return Random.Range((minValue + maxValue) / 2 + 1, maxValue + 1);
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = $"{playerScore}pts";
    }

}
