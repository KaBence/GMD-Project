using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    private Vector2 movement;
    private float speed = 5;

    private int isWalkingHash;
    private int isRunningHash;
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("IsWalking");
        isRunningHash = Animator.StringToHash("IsRunning");
    }


    void Update()
    {
        Vector3 move = new Vector3(movement.x, 0.0f, movement.y);
        transform.position += move * speed * Time.deltaTime;
        if (movement != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(move, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 720 * Time.deltaTime);
        }

        var keyboard = Keyboard.current;
        var gamepad = Gamepad.current;

        bool isHeld = (keyboard != null && keyboard.leftShiftKey.isPressed) ||
                      (gamepad != null && gamepad.leftTrigger.ReadValue() > 0.1f);

        animator.SetBool(isRunningHash, isHeld);
        speed = isHeld ? 10 : 5;
    }

    public void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();
        animator.SetBool(isWalkingHash, movement != Vector2.zero);

    }

    public void OnLeftTrigger(InputValue value)
    {
        // Debug.Log("Left Trigger: " + value.isPressed);
        // if (value.isPressed)
        // {
        //     animator.SetBool(isRunningHash, true);
        //     speed = 10;
        // }
        // else
        // {
        //     animator.SetBool(isRunningHash, false);
        //     speed = 5;
        // }
    }
}
