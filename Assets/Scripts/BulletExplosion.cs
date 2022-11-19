using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosion : MonoBehaviour
{
    public GameObject bulletPrefab;
    private float now;

    private void OnEnable()
    {
        now = Time.time;
    }

    public void Init(Vector3 position, GameObject shooter, int numberOfProjectiles)
    {
        float angleStep = 360 / numberOfProjectiles;
        float centeringOffset = (180) - (angleStep / 2);

        for (int i = 0; i < numberOfProjectiles; i++)
        {
            float currentBulletAngle = angleStep * i;

            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, 0 + currentBulletAngle - centeringOffset));
            GameObject bullet = Pooler.Spawn(bulletPrefab, position, rotation);
        }
    }

    private void Update()
    {
        if (Time.time > now + 1.5f)
        {
            Pooler.Despawn(gameObject);
        }
    }
}
