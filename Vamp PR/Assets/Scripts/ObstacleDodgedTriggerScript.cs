using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDodgedTriggerScript : MonoBehaviour
{
    public int obstaclePoints;
    public Sprite icon;

    public int minValue = 57;
    public int maxValue = 101;
    public float lowProbability = 0.8f;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerScoreCounter>().DodgeObstacle(icon, (obstaclePoints + GenerateRandomNumber()));
        }
    }

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
}
