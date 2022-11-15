using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageField : MonoBehaviour
{
    [SerializeField] private float radius = 3;
    [SerializeField] private LayerMask enemyLayers;
    [SerializeField] private float damagePerTic;
    [SerializeField] private float ticInterval;
    private float lastTicTime;

    private void Update()
    {
        if (Time.time > lastTicTime + ticInterval)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, radius, enemyLayers);

            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Enemy>().TakeDamage(damagePerTic);
            }

            lastTicTime = Time.time;
        }

        transform.eulerAngles = Vector3.forward;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
