using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public InterimBulletData BulletData;
    private float now;

    private Rigidbody2D rb;
    private void OnEnable()
    {
        now = Time.time;
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * BulletData.shotSpeed, ForceMode2D.Impulse);
    }

    public void Initialize(float shotSpeed)
    {
        Debug.Log(shotSpeed);
    }

    private void OnDisable()
    {
       rb.velocity = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(BulletData.damage);
        }
        Pooler.Despawn(gameObject);
    }

    private void Update()
    {
        if (Time.time > now + BulletData.range)
        {
            Pooler.Despawn(gameObject);
        }
    }
}
