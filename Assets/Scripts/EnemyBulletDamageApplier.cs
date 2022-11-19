using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletDamageApplier : MonoBehaviour
{
    public InterimBulletData BulletData;
    private Enemy _enemy;
    private EnemyStates _enemyStates;
    void Start()
    {
        _enemy = gameObject.GetComponent<Enemy>();
        _enemyStates = gameObject.GetComponent<EnemyStates>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _enemy.TakeDamage(BulletData.damage);
            if (BulletData.isBurning)
            {
                _enemyStates.ApplyBurn((BulletData.damage / 20), 1, 3);
            }
        }
    }
}
