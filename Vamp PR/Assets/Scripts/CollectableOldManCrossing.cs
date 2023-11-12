using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class CollectableOldManCrossing : MonoBehaviour
{
    private GameObject scoreKeeper;
    private bool walking = true;
    public float speed = 1f;
    public int scoreIncrease = 1;
    private bool failed = false;
    public Transform end;
    private Animator animator;
    private bool fallingOver = false;
    public float xOffset = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreKeeper = GameObject.FindGameObjectWithTag("ScoreKeeper");
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
                    scoreKeeper.GetComponent<Score>().score += scoreIncrease;
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
}

