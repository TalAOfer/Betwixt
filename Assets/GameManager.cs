using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public InterimBulletData InterimBulletData;
    public BulletData_SO bulletDefaultData;
    public EnemyStatManager enemyStatManager;
    void Start()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Music",GetComponent<Transform>().position);  
        InterimBulletData.Init(bulletDefaultData.shotSpeed, bulletDefaultData.range, bulletDefaultData.damage);
        enemyStatManager.Init(1, false, false);
    }
}
