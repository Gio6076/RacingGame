using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed;
    public float acceleration;
    public float turnSpeed;

    private Rigidbody rb;
    private float currentSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");


        currentSpeed = Mathf.Lerp(currentSpeed, moveInput * maxSpeed, acceleration * Time.fixedDeltaTime);

        Vector3 velocity = transform.forward * currentSpeed;
        velocity.y = rb.velocity.y;

        rb.velocity = velocity;

        if (Mathf.Abs(currentSpeed) > 1f)
        {
            Quaternion turnRotation = Quaternion.Euler(0f, turnInput * turnSpeed * Time.fixedDeltaTime, 0f);
            rb.MoveRotation(rb.rotation * turnRotation);
        }

        //Quaternion turn = Quaternion.Euler(0f, turnInput * turnSpeed * Time.fixedDeltaTime, 0f);
        //rb.MoveRotation(rb.rotation * turn);
    }
}
