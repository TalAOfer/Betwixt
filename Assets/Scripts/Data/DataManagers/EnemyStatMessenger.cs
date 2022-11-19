using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatMessenger : MonoBehaviour
{
    public EnemyStatManager enemyStatManager;

    public void UpdateExplodeOnDeath()
    {
        enemyStatManager.doesExplodeOnDeath = true;
    }
}
