using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CollectableCatInTree : MonoBehaviour
{
    private GameObject scoreKeeper;
    private bool stuck = true;
    public float yOffset = 0f;
    public float speed = 1f;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        scoreKeeper = GameObject.FindGameObjectWithTag("ScoreKeeper");
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
                scoreKeeper.GetComponent<Score>().score++;
                stuck = false;
                if (animator != null)
                {
                    animator.SetBool("stuckIn", stuck);
                }
            }
        }
    }
}
