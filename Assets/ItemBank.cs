using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemBank : MonoBehaviour
{
    public List<Item> allItems = new List<Item>();

    public List<Item> GetNewItems()
    {
        if (allItems.Count >= 2)
        {
            List<Item> newItems = new List<Item>
            {
                allItems[0],
                allItems[1]
            };

            allItems.RemoveRange(0, 2);
            return newItems;
        } else
        {
            Debug.Log("you're out of items");
            return null;
        }

        
    }
}
