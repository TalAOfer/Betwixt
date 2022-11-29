using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Config/Bullets")]
public class Bullet_SO : ScriptableObject
{
    public GameObject bulletPrefab;
    public float damage;
    public float shotSpeed;
    public float range;
}
