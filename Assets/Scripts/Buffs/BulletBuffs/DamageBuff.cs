using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/BulletBuffs/DamageBuff")]
public class DamageBuff : PowerupEffect
{
    public int percentage;
    public InterimBulletData bulletData;
    public override void Apply(GameObject target)
    {
        bulletData.UpdateDamage((float)(percentage + 100) / 100);
    }
}