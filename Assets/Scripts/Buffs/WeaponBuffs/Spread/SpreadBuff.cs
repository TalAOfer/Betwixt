using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/WeaponBuffs/SpreadBuff")]
public class SpreadBuff : PowerupEffect
{
    public int amount;
    public override void Apply(GameObject target)
    {
        target.GetComponentInChildren<Shooting>().UpdateSpread(amount);
    }
}
