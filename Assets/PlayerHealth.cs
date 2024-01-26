using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] float Iframes;
    [SerializeField] float iframetimer;

    [SerializeField] float currenthealth;

    [SerializeField] GameObject HealthUI;   

    public void TakeDamage()
    {
        if (iframetimer < 0)
        {
            currenthealth -= 1;
            iframetimer = Iframes;
        }
    }

    void Start()
    {
        currenthealth = health;
    }

    void Update()
    {
        iframetimer -= Time.deltaTime;

        HealthUI.transform.localScale = new Vector3(currenthealth / health, 1f, 1f);

        if ()
    }
}
