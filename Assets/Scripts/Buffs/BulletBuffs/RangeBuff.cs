using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/BulletBuffs/RangeBuff")]
public class RangeBuff : PowerupEffect
{
    public int percentage;
    public InterimBulletData bulletData;
    public override void Apply(GameObject target)
    {
        bulletData.UpdateRange((float)(percentage + 100) / 100);
    }
}