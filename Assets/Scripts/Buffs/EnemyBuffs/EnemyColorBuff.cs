using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/MonsterBuffs/Color")]
public class EnemyColorBuff : PowerupEffect
{
    public GameEvent OnEnemyColorChange;
    public override void Apply(GameObject target)
    {
        OnEnemyColorChange.Raise();
    }
    
}
