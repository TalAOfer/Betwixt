using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/PlayerBuffs/MovementSpeedBuff")]
public class MovementSpeedBuff : PowerupEffect
{
    public int percentage;
    public override void Apply(GameObject target)
    {
        target.GetComponent<Player>().UpdateMovementSpeed((float)(percentage + 100) / 100);
    }
}
