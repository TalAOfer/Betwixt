using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChoosePlayerUI : MonoBehaviour
{
    [SerializeField] Button ChosenPlayerBtn;
    public List<Player_SO> players = new List<Player_SO>();
    private Player_SO chosenPlayer;
    private Image btnImage;
    private int currPlayerIndex;
    
    void Start()
    {
        currPlayerIndex = 0;
        UpdateChosenPlayer(currPlayerIndex);
    }

    public void UpdateChosenPlayer(int wantedIndex)
    {
        chosenPlayer = players[currPlayerIndex];
        ChosenPlayerBtn.image.sprite = chosenPlayer.icon;
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

    
}
