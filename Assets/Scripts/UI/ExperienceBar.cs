using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    public Image experienceBar;

    private void Start()
    {
        experienceBar.fillAmount = 0;
    }
    public void UpdateExperienceAmount(Component sender, object data)
    {
        float experiencePercentage = (float)data;
        experienceBar.fillAmount = experiencePercentage;
    }
}
