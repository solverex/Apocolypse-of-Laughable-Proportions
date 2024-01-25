using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gassing : MonoBehaviour
{
    Controls _playerInput;

    [Header("Variables")]
    [SerializeField] float sprayspeed;
    public float spraydamage;
    public float hitrate;

    [Header("Components")]
    [SerializeField] ParticleSystem GasPart;
    [SerializeField] GameObject gasObj;

    [Header("Debug")]
    [SerializeField] float gasInput;
    [SerializeField] float scale;
    public float damagetime;

    void Awake()
    {
        _playerInput = new Controls();
    }

    void OnEnable()
    {
        _playerInput.Enable();

        _playerInput.Gameplay.Shooting.performed += OnGas;
        _playerInput.Gameplay.Shooting.canceled += OnGas;
    }

    void OnDisable()
    {
        _playerInput.Disable();
    }

    void OnGas(InputAction.CallbackContext context)
    {
        gasInput = context.ReadValue<float>();
    }

    void Update()
    {
        damagetime -= Time.deltaTime;

        if (gasInput > 0)
        {
            scale += Time.deltaTime * sprayspeed;
            GasPart.Play();
        }
        else
        {
            scale += Time.deltaTime * sprayspeed;
            GasPart.Stop();
        }

        scale = Mathf.Clamp(scale, 0f, 1f);
        gasObj.transform.localScale = new Vector2(scale, scale);
    }
}
