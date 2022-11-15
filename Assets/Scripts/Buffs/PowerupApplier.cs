using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupApplier : MonoBehaviour
{
    public void ApplyBuff(GameObject target, Item item)
    {
        List<PowerupEffect> PowerupEffects = item.powerupEffects;
        foreach (PowerupEffect powerupEffect in PowerupEffects)
        {
            powerupEffect.Apply(target);
        }

    }

}
