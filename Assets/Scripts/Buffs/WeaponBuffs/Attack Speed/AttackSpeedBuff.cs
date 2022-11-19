using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/WeaponBuffs/AttackSpeedBuff")]
public class AttackSpeedBuff : PowerupEffect
{
    public int percentage;
    public override void Apply(GameObject target)
    {
        target.GetComponentInChildren<WeaponController>().UpdateAttackSpeed((float) percentage/100);
    }
}
