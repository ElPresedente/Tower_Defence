using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelUIController : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject PauseButton;

    public GameObject LevelUIPanelText;

    public GameObject TowerUpgradePanel;
    public GameObject TowerUprgadeUIElement;
    public GameObject TowerUpgradeButton;

    public GameObject LevelEndPanel;
    public GameObject LevelEndText;

    private GameManager GameManager;
    private bool isUpgradePanelSet = false;

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
        SceneLoader.LoadScene("MainMenu");
    }
    public void UpdateGameStat()
    {
        LevelUIPanelText.GetComponent<TMP_Text>().text = string.Format("Gold - {0}\nCitadel Health - {1}", GameManager.Gold, GameManager.CitadelGO.GetComponent<Citadel>().Health.HealthPoints);
    }

    public void FirstUpdate(int gold, double health)
    {
        LevelUIPanelText.GetComponent<TMP_Text>().text = string.Format("Gold - {0}\nCitadel Health - {1}", gold, health);
    }

    public void OnUpgradeTowerPanelButtonClick()
    {
        if (!isUpgradePanelSet)
            SetUpgradePanel();
        TowerUpgradePanel.SetActive(!TowerUpgradePanel.activeSelf);
        TowerUpgradeButton.transform.SetAsFirstSibling();
    }

    private void SetUpgradePanel()
    {
        isUpgradePanelSet = true;
        for(int i = 0; i < StaticGameManager.GameManager.TowersArray.Count; i++)
        {
            GameObject UIElement =  Instantiate(TowerUprgadeUIElement, TowerUpgradePanel.transform);
            UIElement.GetComponent<RectTransform>().Translate(new Vector3(0, -75 * i, 0));
            UIElement.GetComponent<TowerUIElement>().SetUIElement(StaticGameManager.GameManager.TowersArray[i], i);
        }
        
    }

    public void EndLevelPanel(string text)
    {
        Time.timeScale = 0;
        LevelEndText.GetComponent<TMP_Text>().text = text;
        LevelEndPanel.SetActive(true);
    }
}
