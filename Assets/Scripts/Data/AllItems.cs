using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/AllItems")]
public class AllItems : ScriptableObject
{
    public List<Item> items;
}
