using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/WeaponBuffs/ChangeWeaponBuff")]
public class ChangeWeaponBuff : PowerupEffect
{
    public Weapon_SO weapon;
    public override void Apply(GameObject target)
    {
        target.GetComponentInChildren<ChangeWeapon>().UpdateWeapon(weapon);
        target.GetComponentInChildren<WeaponController>().UpdateWeapon(weapon);
    }
}
