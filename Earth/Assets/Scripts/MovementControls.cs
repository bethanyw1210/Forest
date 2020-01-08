using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class MovementControls : MonoBehaviour
{
    private Vector3 position;
    private CharacterController controller;

    public float speed = 30f, gravity = -9.8f, jumpHeight = 80f;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        position.x = speed * Input.GetAxis("Horizontal");

        if (controller.isGrounded)
        {
            position.y = 0f;
        }

        if (!controller.isGrounded)
        {
            position.y += gravity;
        }

        if (Input.GetButtonDown("Jump"))
        {
            position.y = jumpHeight;
        }

        controller.Move(position * Time.deltaTime);
    }
}
