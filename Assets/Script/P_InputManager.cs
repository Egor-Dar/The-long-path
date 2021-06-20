using System;
using UnityEngine;

public class P_InputManager : MonoBehaviour
{
    private PlayerControls inputActions;
    private P_Locomotion locomotion;
    private PauseMenu pauseMenu;
    public Vector2 MovementInput { get; private set; }

    private void Awake()
    {
        locomotion = GetComponent<P_Locomotion>();
    }

    private void OnEnable()
    {
        if(inputActions == null)
        {
            inputActions = new PlayerControls();

            inputActions.PlayerMovement.Jump.performed += _ => locomotion.JumpHandler();
            //inputActions.PlayerMovement.Attack.performed += _ => locomotion.AttackHandler();
        }
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void HandleMovementInput()
    {
        MovementInput = inputActions.PlayerMovement.Movement.ReadValue<Vector2>();
    }

    public void HandleAllInputs()
    {
        HandleMovementInput();
    }
}
