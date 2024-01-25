using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] float health;

    public bool inGas;
    public Gassing gasScript;

    public EnemyBehaviour otherscript;

    float damagetime;

    [SerializeField] float currenthealth;

    [SerializeField] GameObject hahaha;

    void Start()
    {
        currenthealth = health;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "gas")
        {
            inGas = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "gas")
        {
            inGas = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "gas")
        {
            inGas = false;
        }
    }

    void Update()
    {
        damagetime -= Time.deltaTime;
        otherscript.inGass = inGas;
        if (inGas)
        {
            hahaha.SetActive(true);
            if (damagetime < 0)
            {
                health -= gasScript.spraydamage;
                damagetime = gasScript.hitrate;
            }
        }
        else
        {
            hahaha.SetActive(false);
        }

        if (health == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
