using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/WeaponBuffs/BulletAmountBuff")]
public class BulletAmountBuff : PowerupEffect
{
    public int amount;
    public override void Apply(GameObject target)
    {
        target.GetComponentInChildren<Shooting>().UpdateBulletAmount(amount);
    }
}
