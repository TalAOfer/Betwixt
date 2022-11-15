using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Data/Managers/EnemyStatManager")]
public class EnemyStatManager : ScriptableObject
{
    public float speedMultiplier = 1;
    public bool doesExplodeOnDeath = false;
    public bool isColored = false;
     

    public void Init(float speed, bool doesExplode, bool isColored)
    {
        this.speedMultiplier = speed;
        this.doesExplodeOnDeath = doesExplode;
        this.isColored = isColored;
    }
    public void UpdateSpeedMultiplier(float amount)
    {
        speedMultiplier += amount / 100;
    }
}

