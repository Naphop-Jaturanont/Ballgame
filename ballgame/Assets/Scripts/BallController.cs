using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 10f;  // The speed of the ball
    public bool canControl = true; // Whether the player can control the ball or not
    
    
    private Rigidbody rb;  // The rigidbody component of the ball
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();  // Get the rigidbody component of the ball
    }

    void FixedUpdate()
    {
        if (canControl)
        {
            float horizontalInput = Input.GetAxis("Horizontal");  // Get the horizontal input axis
            float verticalInput = Input.GetAxis("Vertical");  // Get the vertical input axis

            Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);  // Create a movement vector based on the input

            rb.AddForce(movement * speed);  // Add force to the ball in the direction of the movement vector
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Vector3 force = -collision.impulse;  // Calculate the force of the collision

        rb.AddForce(force);  // Apply the force to the ball in the opposite direction
    }

   
}
