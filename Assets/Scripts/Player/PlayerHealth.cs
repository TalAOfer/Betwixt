using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameEvent OnHealthChange;
    public GameEvent OnPlayerDeath;

    private int maxHealth = 3;
    private int currentHealth;
    private bool isInvincible = false;
    private bool isDead = false;

    [SerializeField] private float hurtCooldown;

    void Start()
    {
        currentHealth = maxHealth;
        OnHealthChange.Raise(this, new int[] { currentHealth, maxHealth });
    }

    public void TakeDamage(int damage, Vector2 enemyPos)
    {
        if (isDead)
        {
            return;
        }

        if (!isInvincible)
        {
            currentHealth -= damage;
            OnHealthChange.Raise(this, new int[] {currentHealth, maxHealth}); 
            isInvincible = true;
            StartCoroutine(HurtCooldown(hurtCooldown));
        }

        if (currentHealth <= 0)
        {
            isDead = true;
            OnPlayerDeath.Raise();
        } 
    }

    private IEnumerator HurtCooldown(float hurtCooldown)
    {
        yield return new WaitForSeconds(hurtCooldown);
        isInvincible = false;
    }

    public void AlterHealth(int amount)
    {
        
        //Increase Health
        if (amount > 0)
        {
            maxHealth += amount;
            currentHealth += amount;
        } else
        //Decrease Health
        {
            //Health is full
            if (currentHealth == maxHealth)
            {
                maxHealth += amount;
                currentHealth += amount;
            //Health isn't full
            } else
            {
                maxHealth += amount;
            }
        }

        OnHealthChange.Raise(this, new int[] { currentHealth, maxHealth });
    }
}
