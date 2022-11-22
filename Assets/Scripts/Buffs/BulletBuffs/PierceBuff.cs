using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/BulletBuffs/PierceBuff")]
public class PierceBuff : PowerupEffect
{
    public InterimBulletData bulletData;
    public int pierceAmount;
    public override void Apply(GameObject target)
    {
        bulletData.isPiercing = true;
        bulletData.pierceAmount = pierceAmount;
    }
}
