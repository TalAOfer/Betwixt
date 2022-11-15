using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnDeath : MonoBehaviour
{
    private Enemy enemy;
    private bool once;
    public GameObject bulletExplosion;
    private GameObject bulletExplosionInstance;

    private void OnEnable()
    {
        enemy = GetComponent<Enemy>();
        once = true;
        Debug.Log(enemy.isDead);
    }

    private void Update()
    {
        if (enemy.isDead && once)
        {
            bulletExplosionInstance = Pooler.Spawn(bulletExplosion, transform.position, transform.rotation);
            bulletExplosionInstance.GetComponent<BulletExplosion>().Init(transform.position, transform.gameObject);
            once = false;
            Debug.Log("Happened");
        }
    }
}
