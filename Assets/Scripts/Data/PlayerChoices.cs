using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Data/PlayerChoices")]
public class PlayerChoices : ScriptableObject
{
    public Player_SO chosenPlayer;
    public Weapon_SO chosenWeapon;
}
