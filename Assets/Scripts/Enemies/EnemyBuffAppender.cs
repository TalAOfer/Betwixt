using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBuffAppender : MonoBehaviour
{
    [SerializeField] private EnemyStatManager enemyStatManager;
    private ExplodeOnDeath explodeOnDeathScript;
    

    private void Start()
    {
        explodeOnDeathScript = GetComponent <ExplodeOnDeath>();
    }
    private void Update()
    {
        if (!explodeOnDeathScript.enabled && enemyStatManager.doesExplodeOnDeath)
        {
            explodeOnDeathScript.enabled = true;
        }
    }


}
