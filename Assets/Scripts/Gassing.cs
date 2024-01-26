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
    [SerializeField] float spraytime;
    [SerializeField] float spraydecreaserate;
    [SerializeField] float sprayincreaserate;
    [SerializeField] float minspray;

    [Header("Components")]
    [SerializeField] GameObject GasCollider;
    [SerializeField] GameObject gasObj;
    [SerializeField] GameObject gasUI;
    [SerializeField] AudioSource aS;

    [Header("Debug")]
    [SerializeField] float gasInput;
    [SerializeField] float scale;
    public float damagetime;
    [SerializeField] float sprayed;
    [SerializeField] bool isSpraying;
    [SerializeField] bool canSpray;

    void Awake()
    {
        _playerInput = new Controls();
        sprayed = spraytime;
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

    void FixedUpdate()
    {
        damagetime -= Time.deltaTime;

        scale = Mathf.Clamp(scale, 0, 1);
        float scalex = scale;
        float scaley = scale;
        GasCollider.transform.localScale = new Vector3(scalex, scaley, 1);
        gasUI.transform.localScale = new Vector3(sprayed / spraytime, 1f, 1f);

        sprayed = Mathf.Clamp(sprayed, 0, spraytime);

        if (canSpray && gasInput > 0)
        {
            isSpraying = true;
            scale += sprayspeed * Time.deltaTime;
            GasCollider.SetActive(true);
            gasObj.SetActive(true);
            sprayed -= spraydecreaserate * Time.deltaTime;
        }
        else
        {
            isSpraying = false;
            scale = 0;
            gasObj.SetActive(false);
            GasCollider.SetActive(false);
            sprayed += sprayincreaserate * Time.deltaTime;
        }

        if (isSpraying)
        {
            if (!aS.isPlaying)
            {
                aS.Play();
            }
        }
        else
        {
            aS.Stop();
        }

        if (isSpraying && sprayed <= 0)
        {
            canSpray = false;
        }
        else if (!isSpraying && sprayed < minspray)
        {
            canSpray = false;
        }
        else
        {
            canSpray = true;
        }
    }
}
