using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public float acceleration = 10f;
    public float friction = 5f;
    public float rotationSpeed = 200f;

    private Rigidbody2D rb;
    private Vector2 velocity;
    private bool moveForward;
    private float rotationInput;

    public ParticleSystem thrustParticles;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveForward = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        rotationInput = 0f;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            rotationInput = 1f;
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            rotationInput = -1f;

        if (moveForward)
        {
            thrustParticles.Play();
        }

        if (!moveForward)
        {
            thrustParticles.Stop();
        }
    }

    void FixedUpdate()
    {
        if (rotationInput != 0f)
        {
            rb.MoveRotation(rb.rotation + rotationInput * rotationSpeed * Time.fixedDeltaTime);
        }

        if (moveForward)
        {
            Vector2 forward = transform.up;
            velocity += forward * acceleration * Time.fixedDeltaTime;
        }
        else
        {
            //FRICCION
            velocity = Vector2.MoveTowards(velocity, Vector2.zero, friction * Time.fixedDeltaTime);
        }
        //VELOCIDAD MAXIMA
        velocity = Vector2.ClampMagnitude(velocity, speed);

        rb.velocity = velocity;
    }
}
