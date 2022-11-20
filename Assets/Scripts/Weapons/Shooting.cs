using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameEvent OnBulletShot;
    
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform attackPoint;
    //private float shotSpeedBuffAmount = 0;

    private float aimingAngle;

    [SerializeField] private int NumberOfProjectiles = 3;

    [Range(0, 360)]
    [SerializeField] private float SpreadAngle = 20;

    public void UpdateAngle(Component sender, object data)
    {
        aimingAngle = (float)data;
    }

    public void Shoot()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Shoot",GetComponent<Transform>().position);  
        float angleStep = SpreadAngle / NumberOfProjectiles;
        float centeringOffset = (SpreadAngle / 2) - (angleStep / 2); //offsets every projectile so the spread is                                                                                                                         //centered on the mouse cursor

        for (int i = 0; i < NumberOfProjectiles; i++)
        {
            float currentBulletAngle = angleStep * i;


            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, aimingAngle + currentBulletAngle - centeringOffset));
            GameObject bullet = Pooler.Spawn(bulletPrefab, firePoint.position, rotation);
            OnBulletShot.Raise(this, rotation);
        }
    }

    public void UpdateBulletAmount(int amount)
    {
        NumberOfProjectiles += amount;
    }

    public void UpdateSpread(int amount)
    {
        SpreadAngle += amount;
    }




}
