using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStates : MonoBehaviour
{
    private Enemy enemy;
    private SpriteRenderer sr;
    private bool isBurning;

    private void OnEnable()
    {
        enemy = GetComponent<Enemy>();
        sr = GetComponent<SpriteRenderer>();
        sr.color = Color.white;
    }

    //BURN
    public void ApplyBurn(float damagePerTic, float ticDelay, float ticAmount)
    {
        sr.color = Color.red;
        
        if (!isBurning)
        {
            isBurning = true;
            StartCoroutine(Burn(damagePerTic, ticDelay, ticAmount));
        }
    }

    private IEnumerator Burn(float damagePerTic, float ticDelay, float ticAmount)
    {
        for (int i = 0; i < ticAmount; i++)
        {
            yield return new WaitForSeconds(ticDelay);
            enemy.TakeDamage(damagePerTic);

            if (i == ticAmount - 1)
            {
                isBurning= false;
                sr.color = Color.white;
            }
        }
    }
}

