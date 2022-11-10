using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float shotSpeed = 15f;
    private float lifetime = 1.5f;
    private float now;

    private Rigidbody2D rb;
    private void OnEnable()
    {
        now = Time.time;
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * shotSpeed, ForceMode2D.Impulse);
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
        Pooler.Despawn(gameObject);
    }

    private void Update()
    {
        if (Time.time > now + lifetime)
        {
            Pooler.Despawn(gameObject);
        }
    }
}
