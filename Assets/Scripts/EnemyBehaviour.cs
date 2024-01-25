using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    // Variables
    [SerializeField] GameObject targetObject;

    [SerializeField] float objectSpeed;

    Vector2 targetPosition;

    Rigidbody2D rb;

    [SerializeField] float spheresize;
    [SerializeField] LayerMask player;


    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, spheresize);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        targetObject = GameObject.FindWithTag("player");
        Vector2 dir = targetObject.transform.position - transform.position;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (!Physics2D.OverlapCircle(transform.position, spheresize, player))
        {
            rb.AddForce(dir.normalized * objectSpeed, ForceMode2D.Force);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player") Debug.Log("attacked player");
    }
}
