using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject MainMenuGO;
    public GameObject LevelsMenuGO;
    public GameObject CreditsMenuGO;
    private void Awake()
    {
        Time.timeScale = 1;
    }
    public void OnStartButtonClick()
    {
        MainMenuGO.SetActive(false);
        LevelsMenuGO.SetActive(true);
    }
    public void OnCreditsButtonClick()
    {
        MainMenuGO.SetActive(false);
        CreditsMenuGO.SetActive(true);
    }
    public void OnExitButtonClick()
    {
        Application.Quit();
    }
    //выбор уровня
    public void OnLevelButtonClick(string level)
    {
        StaticGameManager.levelDataFileName = level;
        SceneManager.LoadScene("LevelScene");
    }
    public void OnBackLevelMenuButtonClick()
    {
        MainMenuGO.SetActive(true);
        LevelsMenuGO.SetActive(false);
    }

    //credit menu
    public void OnBackCreditsMenuBettonClick()
    {
        MainMenuGO.SetActive(true);
        CreditsMenuGO.SetActive(false);
    }
}
