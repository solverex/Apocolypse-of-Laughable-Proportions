using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    Controls _playerInput;

    [Header("Variables")]
    [SerializeField] float movementspeed;
    [SerializeField] float sprintmultiplier;

    [Header("Components")]
    [SerializeField] Camera camera;

    [Header("Debug")]
    [SerializeField] Vector2 _Movement;
    [SerializeField] Vector2 _PointToward;
    [SerializeField] float _Sprint;

    Rigidbody2D rb;

    [SerializeField] GameObject vcam1;
    [SerializeField] GameObject vcam2;

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

        _playerInput.Gameplay.Sprint.performed += OnSprint;
        _playerInput.Gameplay.Sprint.canceled += OnSprint;
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

    void OnSprint (InputAction.CallbackContext context)
    {
        _Sprint = context.ReadValue<float>();
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.right * _Movement.y * movementspeed * (1 + _Sprint * sprintmultiplier));
        rb.AddForce(transform.up * _Movement.x * movementspeed * (1 + _Sprint * sprintmultiplier));

        Vector2 facingDir = _PointToward - rb.position;
        float angle = Mathf.Atan2(facingDir.y, facingDir.x) * Mathf.Rad2Deg;
        rb.MoveRotation(angle);

        if (_Movement.x > 0 || _Movement.y > 0)
        {
            vcam1.SetActive(true);
            vcam2.SetActive(false);
        }
        else
        {
            vcam1.SetActive(false);
            vcam2.SetActive(true);
        }
    }
}
