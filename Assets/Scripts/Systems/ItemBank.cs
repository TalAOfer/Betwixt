using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemBank : MonoBehaviour
{
    [SerializeField] private int defaultAmount = 2;
    public AllItems allItems;
    public List<Item> currentItems;

    private void Start()
    {
        ResetItemList();
    }
    public List<Item> GetNewItems(int amount = -1)
    {
        int chosenAmount = (amount < 1) ? defaultAmount : amount; 

        if (currentItems.Count < chosenAmount)
        {
            ResetItemList();
        } 
            return GetItemsByAmount(chosenAmount);
    }

    private void ResetItemList()
    {
        currentItems = new List<Item>(allItems.items);
    }

    private List<Item> GetItemsByAmount(int chosenAmount)
    {
        List<Item> newItems = new List<Item> { };

        for (int i = 0; i < chosenAmount; i++)
        {
            int rand = Random.Range(0, currentItems.Count);
            Item newItem = currentItems[rand];
            newItems.Add(newItem);
            currentItems.Remove(newItem);
        }

        return newItems;
    }
}
