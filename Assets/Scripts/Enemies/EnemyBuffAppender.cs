using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBuffAppender : MonoBehaviour
{
    [SerializeField] private EnemyStatManager enemyStatManager;
    private EnemyColor enemyColorScript;
    private ExplodeOnDeath explodeOnDeathScript;
    

    private void Start()
    {
        enemyColorScript = GetComponent<EnemyColor>();
        explodeOnDeathScript = GetComponent <ExplodeOnDeath>();
    }
    private void Update()
    {
        if (!enemyColorScript.enabled && enemyStatManager.isColored)
        {
            enemyColorScript.enabled = true;
        }

        if (!explodeOnDeathScript.enabled && enemyStatManager.doesExplodeOnDeath)
        {
            explodeOnDeathScript.enabled = true;
        }
    }


}
