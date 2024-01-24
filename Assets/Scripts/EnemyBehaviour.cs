using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    // Variables
    [SerializeField] GameObject targetObject;

    [SerializeField] float objectSpeed;

    Vector2 targetPosition;


    // Start is called before the first frame update
    void Start()
    {
        targetPosition = targetObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = targetObject.transform.position;

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, objectSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player") Debug.Log("attacked player");
    }
}
