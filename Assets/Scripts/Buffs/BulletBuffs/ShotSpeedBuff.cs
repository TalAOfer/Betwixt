using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/BulletBuffs/ShotSpeedBuff")]
public class ShotSpeedBuff : PowerupEffect
{
    public int amount;
    public override void Apply(GameObject target)
    {
        target.GetComponentInChildren<Shooting>().UpdateShotSpeedBuff(amount);
    }
}