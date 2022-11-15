using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLeveling : MonoBehaviour
{
    public GameEvent OnLevelUp;
    public GameEvent OnGainExperience;

    private int experienceTarget = 50;
    private int currentExperience = 0;
    private int currentLevel = 1;
    [SerializeField] AnimationCurve LevelingCurve;

    public void TakeExperience(int amount)
    {
        currentExperience += amount;
        OnGainExperience.Raise(this, (float) currentExperience / experienceTarget);

        if (currentExperience >= experienceTarget)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        currentExperience -= experienceTarget;
        currentLevel += 1;
        experienceTarget *= 2;
        
        OnLevelUp.Raise();
        OnGainExperience.Raise(this, (float)currentExperience / experienceTarget);
    }
}
