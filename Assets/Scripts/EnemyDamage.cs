using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] float health;

    public bool inGas;
    public Gassing gasScript;

    float damagetime;

    [SerializeField] float currenthealth;

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
        if (inGas)
        {
            if (damagetime < 0)
            {
                health -= gasScript.spraydamage;
                damagetime = gasScript.hitrate;
            }
        }

        if (health == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
