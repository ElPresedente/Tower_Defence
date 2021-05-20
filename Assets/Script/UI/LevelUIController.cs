using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelUIController : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject PauseButton;

    public GameObject LevelUIPanelText;

    private GameManager GameManager;

    private void Start()
    {
        GameManager = StaticGameManager.GameManager;
    }


    public void OnResumeButtonClick()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnPauseButtonClick()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnBackToMenuButtonClick()
    {

    }
    public void UpdateGameStat()
    {
        LevelUIPanelText.GetComponent<TMP_Text>().text = string.Format("Gold - {0}\nCitadel Health - {1}", StaticGameManager.GameManager.)
    }
}
