using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    Controls _playerInput;

    [Header("Variables")]
    [SerializeField] float movementspeed;

    [Header("Components")]
    [SerializeField] Camera camera;

    [Header("Debug")]
    [SerializeField] Vector2 _Movement;
    [SerializeField] Vector2 _PointToward;

    Rigidbody2D rb;

    void Awake()
    {
        _playerInput = new Controls();
        rb = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        _playerInput.Enable();

        _playerInput.Gameplay.Movement.performed += OnMovement;
        _playerInput.Gameplay.Movement.canceled += OnMovement;

        _playerInput.Gameplay.Aiming.performed += OnAim;
    }

    void OnDisable()
    {
        _playerInput.Disable();
    }

    void OnMovement(InputAction.CallbackContext context)
    {
        _Movement = context.ReadValue<Vector2>();
    }

    void OnAim (InputAction.CallbackContext context)
    {
        _PointToward = camera.ScreenToWorldPoint(context.ReadValue<Vector2>());
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.right * _Movement.y * movementspeed);
        rb.AddForce(transform.up * _Movement.x * movementspeed);

        Vector2 facingDir = _PointToward - rb.position;
        float angle = Mathf.Atan2(facingDir.y, facingDir.x) * Mathf.Rad2Deg;
        rb.MoveRotation(angle);
    }
}
