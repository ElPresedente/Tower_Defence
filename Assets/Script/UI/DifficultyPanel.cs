using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DifficultyPanel : MonoBehaviour
{
    
    private SelectedDifficulty CurrentDifficulty;

    [Tooltip("Объект панели сложности")]
    public GameObject InfoPanel;
    private Image InfoPanelImage; //компонент панели для изменения цвета
    [Tooltip("Объект текста панели")]
    public TMP_Text InfoPanelText;
    [Space]
    [Header("Цвета панели описания сложности")]
    public Color[] DifficultyColors;
    [Space]
    [Header("Строки описания сложности")]
    public string[] DifficultyDescriptions;
    [Space]
    [Tooltip("Кнопка начала игры")]
    public GameObject StartGameButton;
    

    private void Awake()
    {
        InfoPanelImage = InfoPanel.GetComponent<Image>();
    }
    public void DifficultyChoice(string type)
    {
        if (!InfoPanel.activeSelf)
        {
            InfoPanel.SetActive(true);
        }
        if (!StartGameButton.activeSelf)
        {
            StartGameButton.SetActive(true);
        }
        switch (type)
        {
            case "Easy":
                CurrentDifficulty = SelectedDifficulty.Easy;
                break;
            case "Normal":
                CurrentDifficulty = SelectedDifficulty.Normal;
                break;
            case "Hard":
                CurrentDifficulty = SelectedDifficulty.Hard;
                break;
        }
        //изменение цвета панели
        InfoPanelImage.color = DifficultyColors[(int)CurrentDifficulty];
        //изменение текста на панели
        InfoPanelText.text = DifficultyDescriptions[(int)CurrentDifficulty];
        
    }
    public void StartLoadlevel()
    {
        SceneLoader.LoadScene("LevelScene");
    }
}
