using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementRigidBody : MonoBehaviour
{
    Rigidbody rb;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = (transform.right * horizontal + transform.forward * vertical);
        direction *= speed;
        direction.y = rb.velocity.y;

        rb.velocity = direction;
    }
}
