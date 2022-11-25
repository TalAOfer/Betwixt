using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public GameObject MainMenuParent;

    public GameEvent OnPauseGame;
    public GameEvent OnResumeGame;


    public void EnableMainMenu()
    {
        OnPauseGame.Raise();
        MainMenuParent.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        OnResumeGame.Raise();
        MainMenuParent.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
