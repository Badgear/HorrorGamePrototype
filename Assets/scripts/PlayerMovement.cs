using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 10f;
    public float crouchSpeed = 1f;
    public float sprintSpeed = 30f;
    public float gravity = -8f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.8f;
    public LayerMask groundMask;

    bool isGrounded;
    Vector3 velocity;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKey("c"))
        {
            controller.height = 1.5f;
            controller.Move(move * crouchSpeed * Time.deltaTime);
        }
        else
        {
            controller.height = 3f;
            controller.Move(move * speed * Time.deltaTime);
        }

        if
            (Input.GetKey("left shift"))
        {
            controller.Move(move * sprintSpeed * Time.deltaTime);
        }
        else
        {
            controller.Move(move * speed * Time.deltaTime);
        }
    }
}
