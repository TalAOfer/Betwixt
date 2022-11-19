using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemBank : MonoBehaviour
{
    [SerializeField] private int defaultAmount = 2;
    public List<Item> allItems = new List<Item>();

    public List<Item> GetNewItems(int amount = -1)
    {
        int chosenAmount = (amount < 1) ? defaultAmount : amount; 

        if (allItems.Count >= chosenAmount)
        {
            List<Item> newItems = new List<Item> { };

            for (int i = 0 ; i < chosenAmount; i++)
            {
                int rand = Random.Range(0, allItems.Count);
                Item newItem = allItems[rand];
                newItems.Add(newItem);
                allItems.Remove(newItem);
            }            

            return newItems;
        } else
        {
            Debug.Log("you're out of items");
            return null;
        }
    }
}
