using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;
    private PlayerMotor motor;
    private PlayerLook look;


    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot; 
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>(); 
        onFoot.Jump.performed += ctx => motor.Jump(); // ctx is a pointer called context for this jump performed 
        onFoot.Crouch.performed += ctx => motor.Crouch();
        onFoot.Sprint.performed += ctx => motor.Sprint();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //tell the playerMotor to move using the value from our movement action 
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }
    private void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }
    private void OnEnable()
    {
        onFoot.Enable();
    }
    private void OnDisable()
    {
        onFoot.Disable();
    }
}
    