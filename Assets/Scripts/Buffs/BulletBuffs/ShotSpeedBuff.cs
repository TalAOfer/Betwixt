using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/BulletBuffs/ShotSpeedBuff")]
public class ShotSpeedBuff : PowerupEffect
{
    public int percentage;
    public InterimBulletData bulletData;
    public override void Apply(GameObject target)
    {
        bulletData.UpdateShotSpeedBuff((float) (percentage + 100) / 100);
    }
}