using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Managers/CurrentBulletData")]
public class InterimBulletData : ScriptableObject
{
    public float shotSpeedBuff;
    public float rangeBuff;
    public float damageBuff;
    public float sizeBuff;

    public bool isPiercing;
    public int pierceAmount;

    public bool isBurning;

    public Bullet_SO currBullet;

    public void Init(Bullet_SO bullet_so)
    {
        currBullet = bullet_so;

        shotSpeedBuff = 1;
        rangeBuff = 1;
        damageBuff = 1;
        sizeBuff = 1;

        isPiercing = false;
        pierceAmount = 2;
        isBurning = false;
    }

    public void UpdateCurrBullet(Bullet_SO bullet_so)
    {
        currBullet = bullet_so;
    }
    public void UpdateShotSpeedBuff(float amount)
    {
        shotSpeedBuff *= amount;
    }

    public void UpdateRange(float amount)
    {
        rangeBuff *= amount;
    }

    public void UpdateDamage(float amount)
    {
        damageBuff *= amount;
    }

    public void UpdateSize(float amount)
    {
        sizeBuff *= amount;
    }
}
