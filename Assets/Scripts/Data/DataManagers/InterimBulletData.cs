using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Managers/CurrentBulletData")]
public class InterimBulletData : ScriptableObject
{
    public float shotSpeed;
    public float range;
    public float damage;

    public void Init(float shotSpeed, float range, float damage)
    {
        this.shotSpeed = shotSpeed;
        this.range = range;
        this.damage = damage;
    }
    public void UpdateShotSpeedBuff(float amount)
    {
        shotSpeed *= amount;
    }

    public void UpdateRange(float amount)
    {
        range *= amount;
    }

    public void UpdateDamage(float amount)
    {
        damage *= amount;
    }
}
