using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmniShot : MonoBehaviour
{
    public GameObject bulletExplosionPrefab;
    private int numberOfBullets = 2;
    private int chanceOfOmni = 2;
    public void ApplyOmnishot(Component sender, object data)
    {
       int rand = Random.Range(0, 10);
       if (rand > chanceOfOmni)
       {
           return;
       }

       Quaternion rotation = (Quaternion) data;
       GameObject bulletExplosion = Pooler.Spawn(bulletExplosionPrefab, transform.position, rotation);
       bulletExplosion.GetComponent<BulletExplosion>().Init(transform.position, transform.gameObject, numberOfBullets);
    }

    public void Init(int bulletNum, int chanceNum)
    {
        numberOfBullets = bulletNum;
        chanceOfOmni = chanceNum;
    }

}
