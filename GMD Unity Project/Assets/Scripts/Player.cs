using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    private Rigidbody rb;
    private Vector2 movement;
    private float speed = 5;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 move = new Vector3(movement.x, 0.0f, movement.y);
        rb.AddForce(move * speed);
    }
    
    public void OnMovement(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
    
    public void OnA()
    {
        // text.text = "A";
    }
    
    public void OnB()
    {
        // text.text = "B";
    }
    
    public void OnX()
    {
        // text.text = "X";
    }
    
    public void OnY()
    {
        // text.text = "Y";
    }
    
    public void OnLeftTrigger()
    {
        // text.text = "L Trigger";
    }
    
    public void OnRightTrigger()
    {
        // text.text = "R Trigger";
    }
    
    public void OnStart()
    {
        // text.text = "Start";
    }
}
