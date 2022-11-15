using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Item")]
public class Item : ScriptableObject
{
    public List<PowerupEffect> powerupEffects = new List<PowerupEffect>();
    public string itemName;

    public Sprite icon;

    [TextArea(3,8)]
    public string Description;
}
