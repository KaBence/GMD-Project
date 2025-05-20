using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    private Vector2 movement;
    private float speed = 5;

    private int isWalkingHash;
    private int isRunningHash;
    private Animator animator;

    [SerializeField] private float jumpPower = 5f;

    private Rigidbody rb;
    private CapsuleCollider capsuleCollider;

    void Awake()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("IsWalking");
        isRunningHash = Animator.StringToHash("IsRunning");
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
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

    }

    public void OnMovement(InputAction.CallbackContext value)
    {
        movement = value.ReadValue<Vector2>();
        animator.SetBool(isWalkingHash, movement != Vector2.zero);
    }

    public void OnLeftTrigger(InputAction.CallbackContext value)
    {
        // Debug.Log("Left Trigger: " + value.isPressed);
        if (value.phase == InputActionPhase.Started)
        {
            animator.SetBool(isRunningHash, true);
            speed = 10;
        }
        else if (value.phase == InputActionPhase.Canceled)
        {
            animator.SetBool(isRunningHash, false);
            speed = 5;
        }
    }

    public void OnA(InputAction.CallbackContext value)
    {
        Debug.Log("A: ");
        if (value.phase == InputActionPhase.Started)
        {
            animator.SetTrigger("Jump");
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
        else if (value.phase == InputActionPhase.Canceled)
        {
            animator.ResetTrigger("Jump");
        }
    }

    public void OnRightTrigger(InputAction.CallbackContext value)
    {
        if (!animator.GetBool(isRunningHash))
            return;
        Vector3 inputDirection = new Vector3(movement.x, 0.0f, movement.y);

        if (value.phase == InputActionPhase.Started)
        {
            Debug.Log("RT: ");
            animator.SetTrigger("Sliding");
            rb.AddForce(inputDirection.normalized * 10f, ForceMode.Impulse);

            capsuleCollider.height = 0.5f;
            capsuleCollider.center = new Vector3(0, 0.25f, 0);
        }
        else if (value.phase == InputActionPhase.Canceled)
        {
            capsuleCollider.height = 1f;
            capsuleCollider.center = new Vector3(0, 0.5f, 0);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("HIT!");
        }
    }
}
