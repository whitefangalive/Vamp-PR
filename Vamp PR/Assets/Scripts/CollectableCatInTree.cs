using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CollectableCatInTree : MonoBehaviour
{
    private bool stuck = true;
    public float yOffset = 0f;
    public float speed = 1f;
    private Animator animator;
    public int obstaclePoints;
    public Sprite icon;

    public int minValue = 57;
    public int maxValue = 101;
    public float lowProbability = 0.8f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (animator.GetBool("stuckIn") == false) 
        {
            transform.position = new Vector2(transform.position.x - (speed), transform.position.y);
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && stuck == true)
        {
            if (other.GetComponent<PlayerMovement>().isGrounded == false)
            {
                transform.position = new Vector2(other.transform.position.x, other.transform.position.y + yOffset);
            }
            else 
            {
                
                stuck = false;
                if (animator != null)
                {
                    animator.SetBool("stuckIn", stuck);
                }
                other.gameObject.GetComponent<PlayerScoreCounter>().DodgeObstacle(icon, (obstaclePoints + GenerateRandomNumber()));
            }
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
