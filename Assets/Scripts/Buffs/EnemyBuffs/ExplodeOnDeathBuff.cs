using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/MonsterBuffs/ExplodeOnDeath")]
public class ExplodeOnDeathBuff : PowerupEffect
{
    public GameEvent OnEnemyAddExplodeOnDeath;
    public GameObject whatExplodes;
    public override void Apply(GameObject target)
    {
        OnEnemyAddExplodeOnDeath.Raise(null, whatExplodes);
    }

}
