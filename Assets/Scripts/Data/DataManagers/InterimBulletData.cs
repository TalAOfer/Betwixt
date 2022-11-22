using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Managers/CurrentBulletData")]
public class InterimBulletData : ScriptableObject
{
    public float shotSpeed;
    public float range;
    public float damage;
    public float size;

    public bool isPiercing;
    public int pierceAmount;

    public bool isBurning;

    public void Init(float shotSpeed, float range, float damage)
    {
        this.shotSpeed = shotSpeed;
        this.range = range;
        this.damage = damage;
        this.size = 1;

        this.isPiercing = false;
        this.pierceAmount = 2;

        this.isBurning = false;
        
        
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

    public void UpdateSize(float amount)
    {
        size *= amount;
    }
}
