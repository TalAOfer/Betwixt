using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public InterimBulletData BulletData;
    private float now;
    
    private int enemiesHit = 0;

    private Rigidbody2D rb;
    private void OnEnable()
    {
        now = Time.time;
        enemiesHit = 0;
        transform.localScale = Vector3.one * BulletData.size;
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * BulletData.shotSpeed, ForceMode2D.Impulse);
    }

    private void OnDisable()
    {
       rb.velocity = Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (!BulletData.isPiercing)
            {
                Pooler.Despawn(gameObject);
            } else
            {
                enemiesHit++;
                if (enemiesHit > BulletData.pierceAmount)
                {
                    Pooler.Despawn(gameObject);
                }
            }
        }

       
    }

    private void Update()
    {
        if (Time.time > now + BulletData.range)
        {
            Pooler.Despawn(gameObject);
        }
    }



}
