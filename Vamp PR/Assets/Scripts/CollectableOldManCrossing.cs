using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CollectableOldManCrossing : MonoBehaviour
{
    private bool walking = true;
    public float speed = 1f;
    private bool failed = false;
    public Transform end;
    private Animator animator;
    private bool fallingOver = false;
    public float xOffset = 0;
    public int obstaclePoints = 10;
    public Sprite icon;

    public int minValue = 0;
    public int maxValue = 9;
    public float lowProbability = 0.8f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void UpdateaAnimation()
    {
        if (animator != null)
        {
            animator.SetBool("walking", walking);
        }
    }
    private void Update()
    {
        if (fallingOver == true)
        {
            if (transform.rotation.z > -0.7 && transform.rotation.z < 1)
            {
                transform.Rotate(new Vector3(0.0f, 0.0f, -1f));
            }
            if (transform.position.y > 2.5)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - 0.1f);
            }
        }
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && failed == false)
        {
            if (other.GetComponent<PlayerMovement>().isGrounded == true)
            {
                walking = true;
                transform.position = new Vector2(other.transform.position.x + xOffset, transform.position.y);
                if (transform.position.x >= end.position.x)
                {
                    other.gameObject.GetComponent<PlayerScoreCounter>().DodgeObstacle(icon, (obstaclePoints + GenerateRandomNumber()));
                    walking = false;
                    failed = true;// but not actually
                }
                UpdateaAnimation();
            }
            else 
            {
                failed = true;
                walking = false;
                UpdateaAnimation();
                fallingOver = true;
            }
        }
    }
    private int GenerateRandomNumber()
    {
        float randomValue = UnityEngine.Random.value;

        // Apply probability distribution
        if (randomValue < lowProbability)
        {
            // Generate a low number with higher probability
            return UnityEngine.Random.Range(minValue, (minValue + maxValue) / 2 + 1);
        }
        else
        {
            // Generate a high number with lower probability
            return UnityEngine.Random.Range((minValue + maxValue) / 2 + 1, maxValue + 1);
        }
    }
}

