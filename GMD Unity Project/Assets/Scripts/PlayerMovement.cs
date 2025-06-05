using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public Vector2 movement;

    private int isWalkingHash;
    private int isRunningHash;
    private int IsSlidingHash;
    private Animator animator;


    private Rigidbody rb;
    private CapsuleCollider capsuleCollider;
    private HandlePlayerSpeed playerSpeed;

    private bool isSlidingunlocked = false;
    private bool isSliding = false;

    public LayerMask groundLayer;
    private float groundCheckDistance = 0.4f;
    private Coroutine slideCoroutine;

    void Awake()
    {
        isSlidingunlocked = PlayerPrefs.GetFloat(IUpgradeables.slidingKey, 0) == 1;
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("IsWalking");
        isRunningHash = Animator.StringToHash("IsRunning");
        IsSlidingHash = Animator.StringToHash("IsSliding");
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        playerSpeed = GetComponent<HandlePlayerSpeed>();
    }


    void FixedUpdate()
    {
        Vector3 move = new Vector3(movement.x, 0.0f, movement.y);

        rb.MovePosition(rb.position + move * playerSpeed.speed * Time.fixedDeltaTime);
        if (movement != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(move, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 720 * Time.deltaTime);
        }
    }

    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);
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
            playerSpeed.IsRunning = true;
            playerSpeed.UpdatePlayerSpeed();
        }
        else if (value.phase == InputActionPhase.Canceled)
        {
            animator.SetBool(isRunningHash, false);
            playerSpeed.IsRunning = false;
            playerSpeed.UpdatePlayerSpeed();
        }
    }

    public void OnA(InputAction.CallbackContext value)
    {
        if (isSliding)
        {
            Debug.Log("Cannot jump while sliding.");
            return;
        }

        if (!IsGrounded())
        {
            Debug.Log("Cannot jump while in the air.");
            return;
        }

        if (value.phase == InputActionPhase.Started)
        {
            Debug.Log("A: ");
            animator.SetTrigger("Jump");
            rb.AddForce(Vector3.up * playerSpeed.jumpPower, ForceMode.Impulse);
        }
        else if (value.phase == InputActionPhase.Canceled)
        {
            animator.ResetTrigger("Jump");
        }
    }

    public void OnRightTrigger(InputAction.CallbackContext value)
    {
        if (!isSlidingunlocked)
        {
            Debug.Log("Sliding is not unlocked.");
            return;
        }

        if (!animator.GetBool(isRunningHash))
            return;

        if (isSliding)
            return;
        
        Vector3 inputDirection = new Vector3(movement.x, 0.0f, movement.y);

        if (value.phase == InputActionPhase.Started)
        {
            Debug.Log("RT: ");
            animator.SetBool(IsSlidingHash, true);
            rb.AddForce(inputDirection.normalized * 10f, ForceMode.Impulse);

            capsuleCollider.height = 1f;
            capsuleCollider.center = new Vector3(0, 0.25f, 0);
            isSliding = true;

            if (slideCoroutine != null)
                StopCoroutine(slideCoroutine);
            slideCoroutine = StartCoroutine(AutoEndSlide(0.8f));
        }
    }

    private IEnumerator AutoEndSlide(float duration)
    {
        yield return new WaitForSeconds(duration);
        animator.SetBool(IsSlidingHash, false);
        ResetCapsuleCollider();
        isSliding = false;
        slideCoroutine = null;
    }

    private void ResetCapsuleCollider()
    {
        capsuleCollider.height = 2f;
        capsuleCollider.center = new Vector3(0, 0.8f, 0);
    }
}
