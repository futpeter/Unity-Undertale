using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public HeartStats heartStats;
    public int damage = 2;
    public float speed = 1.0f;
    private Rigidbody2D rb;
    public bool canDestroy;

    // Start is called before the first frame update
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Heart")
        {
            heartStats.TakeDamage(damage);

            if (canDestroy == true)
            {
                Destroy(gameObject);
            }

        }
        else if (collision.gameObject.tag == "Border")
        {
            if (canDestroy == true)
            {
                Destroy(gameObject);
            }
        }
    }
}
