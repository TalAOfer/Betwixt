using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/BulletBuffs/ChangeBulletBuff")]
public class ChangeBulletBuff : PowerupEffect
{
    public GameObject bulletType;
    public override void Apply(GameObject target)
    {
        target.GetComponentInChildren<Shooting>().UpdateBulletType(bulletType);
    }
}
