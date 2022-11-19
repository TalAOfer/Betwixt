using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;

    void Start()
    {
        
    }

    // Update is called once per frame
    public void UpdateHealth(Component sender, object data)
    {

        int[] currPlayerHealth = (int[])data;
        int currentHealth = currPlayerHealth[0];
        int maxHealth = currPlayerHealth[1];

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < maxHealth)
            {
                hearts[i].enabled = true;

                if (i < currentHealth)
                {
                    hearts[i].sprite = fullHeart;
                } else
                {
                    hearts[i].sprite = emptyHeart;
                }
            } else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
