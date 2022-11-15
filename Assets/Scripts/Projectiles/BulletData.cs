using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletData : MonoBehaviour
{
    private void Start()
    {
        
    }

    public static float shotSpeed = 10;
    public static float range = 0.5f;
    public static float damage = 25;

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
