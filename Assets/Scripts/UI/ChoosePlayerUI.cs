using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChoosePlayerUI : MonoBehaviour
{
    [SerializeField] Button ChosenPlayerBtn;
    [SerializeField] Button ChosenWeaponBtn;

    [SerializeField] PlayerChoices playerChoices;

    public List<Player_SO> players = new List<Player_SO>();
    public List<Weapon_SO> weapons = new List<Weapon_SO>();

    private Player_SO chosenPlayer;
    private Weapon_SO chosenWeapon;

    private int currPlayerIndex;
    private int currWeaponIndex;
    
    void Start()
    {
        currPlayerIndex = 0;
        UpdateChosenPlayer(currPlayerIndex);
        UpdateChosenWeapon(currWeaponIndex);
    }

    public void UpdateChosenPlayer(int wantedIndex)
    {
        chosenPlayer = players[wantedIndex];
        ChosenPlayerBtn.image.sprite = chosenPlayer.icon;
        playerChoices.chosenPlayer = chosenPlayer;
    }

    public void UpdateChosenWeapon(int wantedIndex)
    {
        chosenWeapon = weapons[wantedIndex];
        ChosenWeaponBtn.image.sprite = chosenWeapon.icon;
        playerChoices.chosenWeapon = chosenWeapon;
    }

    public void NextPlayer()
    {
        
        if (currPlayerIndex != players.Count - 1)
        {
            currPlayerIndex++;
        } else
        {
            currPlayerIndex = 0;
        }

        UpdateChosenPlayer(currPlayerIndex);
    }

    public void PrevPlayer()
    {
        if (currPlayerIndex != 0)
        {
            currPlayerIndex--;
        }
        else
        {
            currPlayerIndex = players.Count - 1;
        }
         
        UpdateChosenPlayer(currPlayerIndex);
    }

    public void NextWeapon()
    {

        if (currWeaponIndex != weapons.Count - 1)
        {
            currWeaponIndex++;
        }
        else
        {
            currWeaponIndex = 0;
        }

        UpdateChosenWeapon(currWeaponIndex);
    }

    public void PrevWeapon()
    {
        if (currWeaponIndex != 0)
        {
            currWeaponIndex--;
        }
        else
        {
            currWeaponIndex = weapons.Count - 1;
        }

        UpdateChosenWeapon(currWeaponIndex);
    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
