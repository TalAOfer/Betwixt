using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    private Animator anim;
    private Shooting shootingScript;
    private WeaponController weaponControllerScript;
    private void Start()
    {
        anim = GetComponent<Animator>();
        shootingScript= GetComponent<Shooting>();
        weaponControllerScript = GetComponent<WeaponController>();
    }

    public void UpdateWeapon(Weapon_SO weapon)
    {
        shootingScript.UpdateWeapon(weapon);
        weaponControllerScript.UpdateWeapon(weapon);
        anim.runtimeAnimatorController = weapon.overrideAnim;
    }
}
