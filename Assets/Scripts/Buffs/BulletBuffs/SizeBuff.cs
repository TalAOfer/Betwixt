using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/BulletBuffs/SizeBuff")]
public class SizeBuff : PowerupEffect
{
    public int percentage;
    public InterimBulletData bulletData;
    public override void Apply(GameObject target)
    {
        bulletData.UpdateSize((float)(percentage + 100) / 100);
    }
}