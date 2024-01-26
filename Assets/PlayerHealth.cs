using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] float Iframes;
    [SerializeField] float iframetimer;

    [SerializeField] float currenthealth;

    [SerializeField] GameObject HealthUI;

    [SerializeField] AudioSource aS;

    public void TakeDamage()
    {
        if (iframetimer < 0)
        {
            aS.Play();
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

        if (currenthealth <= 0)
        {
            SceneManager.LoadScene(3);
        }
    }
}
