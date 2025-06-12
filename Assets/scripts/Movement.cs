using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] float velocity;
    [SerializeField] float speed;
    [SerializeField] float friction;
    [SerializeField] float maxSpeed;


    private void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.up);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.rotation += 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.rotation += -1;
        }

        if (rb.velocity.y > maxSpeed)
        {
            speed = maxSpeed;
        }

        //friccion
        //Vector3.MoveTowards(rb.velocity, ,);
    }
}
