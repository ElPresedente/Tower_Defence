using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // ссылки на объекты сцены для наглядного управления
    private Transform canvas;
    private GameObject mainMenu;
    private GameObject difficultyMenu;
    private GameObject settingsMenu;

    private void Awake()
    {
        canvas = transform.GetChild(0);
        mainMenu = canvas.Find("MainMenuPanel").gameObject;
        difficultyMenu = canvas.Find("DifficultyPanel").gameObject;
        settingsMenu = canvas.Find("SettingsPanel").gameObject;
    }
    public void OnStartButtonClick()
    {
        mainMenu.SetActive(false);
        difficultyMenu.SetActive(true);
    }
    public void OnSettingsButtonClick()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }
    public void OnStatsButtonClick()
    {

    }
    public void OnCreditsButtonClick()
    {

    }
    public void OnExitButtonClick()
    {
        Application.Quit();
    }
    
    // кнопки в настройках
    public void OnSettingsExitButtonClick()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }
}
