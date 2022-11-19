using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/BulletBuffs/BurnBuff")]
public class BurnBuff : PowerupEffect
{
    public InterimBulletData bulletData;
    public override void Apply(GameObject target)
    {
        bulletData.isBurning = true;
    }
}
