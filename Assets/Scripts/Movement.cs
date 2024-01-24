using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    Controls _playerInput;

    void Awake()
    {
        _playerInput = new Controls();
    }

    void OnEnable()
    {
        _playerInput.Enable();

        _playerInput.Gameplay.Movement.performed += OnMovement;
        _playerInput.Gameplay.Movement.canceled += OnMovement;
    }

    void OnDisable()
    {
        _playerInput.Disable();
    }

    void OnMovement(InputAction.CallbackContext context)
    {
        Vector2 _Movement = context.ReadValue<Vector2>();
    }
}
