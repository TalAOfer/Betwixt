using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Powerups/PlayerBuffs/HealthBuff")]
public class HealthBuff : PowerupEffect
{
    public int amount;
    public override void Apply(GameObject target)
    {
        target.GetComponent<PlayerHealth>().AlterHealth(amount);
    }
}
