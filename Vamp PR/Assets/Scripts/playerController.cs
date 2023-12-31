using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float jumpForce;
    public float moveSpeed = 1;
    public float currentSpeed = 1;
    private bool isJumping = false;
    public float checkRadius;
    public Transform ceilingCheck;
    public Transform groundCheck;
    public LayerMask groundObject;
    private bool isGrounded;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        currentSpeed = rb.velocity.magnitude;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundObject);
        if (isJumping == true)
        {
            rb.AddForce(new Vector2(0, jumpForce));
        }
        isJumping = false;
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

    }
    private void Update()
    {
        if (Input.GetKeyDown("space") && isGrounded)
        {
            isJumping = true;
        }
    }
}
