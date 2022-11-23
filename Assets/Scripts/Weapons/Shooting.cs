using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameEvent OnBulletShot;
    
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    public Weapon_SO currWeapon; 

    private float aimingAngle;

    private float spreadBuff = 0;
    private int bulletAmountBuff = 0;

    public void UpdateAngle(Component sender, object data)
    {
        aimingAngle = (float)data;
    }

    public void Shoot()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Shoot",GetComponent<Transform>().position);  
        float angleStep = (currWeapon.spread + spreadBuff) / currWeapon.bulletAmount;
        float centeringOffset = ((currWeapon.spread + spreadBuff) / 2) - (angleStep / 2); //offsets every projectile so the spread is                                                                                                                         //centered on the mouse cursor

        for (int i = 0; i < currWeapon.bulletAmount; i++)
        {
            float currentBulletAngle = angleStep * i;


            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, aimingAngle + currentBulletAngle - centeringOffset));
            GameObject bullet = Pooler.Spawn(bulletPrefab, firePoint.position, rotation);
            OnBulletShot.Raise(this, rotation);
        }
    }

    public void UpdateBulletAmount(int amount)
    {
        bulletAmountBuff += amount;
    }

    public void UpdateSpread(int amount)
    {
        spreadBuff += amount;
    }

    public void UpdateWeapon(Weapon_SO newWeapon)
    {
        currWeapon = newWeapon;

    }

    public void UpdateBulletType(GameObject bulletType)
    {
        bulletPrefab = bulletType;
    }
}
