using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelUpUI : MonoBehaviour
{
    public GameEvent OnPauseGame;
    public GameEvent OnResumeGame;

    public static bool isGamePaused = false;
    
    public GameObject levelUpUI;

    public TextMeshProUGUI option0Name;
    public TextMeshProUGUI option0Description;
    public Image option0icon;

    public TextMeshProUGUI option1Name;
    public TextMeshProUGUI option1Description;
    public Image option1icon;


    private Item item0;
    private Item item1;

    public ItemBank itemBank;

    public GameObject player;
    public GameObject enemyStatMessenger;

    private PowerupApplier powerupApplier;

    private void Start()
    {
        powerupApplier = GetComponent<PowerupApplier>();
        LoadNewItems();

    }

    private void UpdateItems()
    {
        option0Name.SetText(item0.itemName);
        option1Name.SetText(item1.itemName);
        if (item0.icon != null) 
        {
            option0icon.sprite = item0.icon;
        }

        option0Description.SetText(item0.Description);
        option1Description.SetText(item1.Description);
        if (item1.icon != null) 
        {
            option1icon.sprite = item1.icon;
        }
    }
    public void OnPlayerChoice(int index)
    {
        switch(index)
        {
            case 0:
                powerupApplier.ApplyBuff(player, item0);
                break;
            case 1:
                powerupApplier.ApplyBuff(player, item1);
                break;
        }

        DisableLevelUpUI();
    }

    public void EnableLevelUpUI()
    {
        OnPauseGame.Raise();
        levelUpUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
        
    }

    private void DisableLevelUpUI()
    {
        OnResumeGame.Raise();
        
        //Prepare items for next level-up 
        LoadNewItems();

        levelUpUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    public void LoadNewItems()
    {
        //Get list of new items from bank
        List<Item> newItems = itemBank.GetNewItems();

        if (newItems == null)
        {
            return;
        }

        //Append new items to vars
        item0 = newItems[0];
        item1 = newItems[1];

        //Update UI with new Items
        UpdateItems();
    }

}
