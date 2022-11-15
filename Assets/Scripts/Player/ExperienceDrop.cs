using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceDrop : MonoBehaviour
{
    private int experienceAmount = 20;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerLeveling>().TakeExperience(experienceAmount);
            Destroy(gameObject);
        }
    }
}
