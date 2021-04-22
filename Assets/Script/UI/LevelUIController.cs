using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUIController : MonoBehaviour
{
    [Space]
    [Header("Панели, используемые в интерфейсе игровго уровня")]
    [Tooltip("Взаимодействие пользователя с игрой")]
    public GameObject InterfacePanel;
    [Tooltip("Взаимодействие пользователя с меню")]
    public GameObject StopGamePanel;

    public void Awake()
    {
        Time.timeScale = 1;         // Выравниваем временной поток и искривления пространства :)
        // Настраиваем правильную последовательность слоёв в UI при загрузке сцены
        InterfacePanel.SetActive(true);
        StopGamePanel.SetActive(false);
    }
    public void OnPauseGameButtonClick()
    {
        Time.timeScale = 0;     // Останавливаем игру
        InterfacePanel.SetActive(false);
        StopGamePanel.SetActive(true);
    }
    public void OnResumeGameButtonClick()
    {
        Time.timeScale = 1;     // Возобновляем игру
        StopGamePanel.SetActive(false);
        InterfacePanel.SetActive(true);
    }
    public void OnBackToMainMenuButtonClick()
    {
        //TODO: Памагити сделать загрузку
        SceneManager.LoadScene("MainMenu");
    }
    public void OnExitGameButtonClick()
    {
        //TODO: Вызывать панель предупреждения при нажатии данной кнопки: "Вы точно хотите выйти из игры?"
        Application.Quit();
    }

    public void OnTimeScaleNormalButtonClick()
    {
        Time.timeScale = 1.0f;
    }
    public void OnTimeScaleOneAndHalfButtonClick()
    {
        Time.timeScale = 1.5f;
    }
    public void OnTimeScaleZeroAndHalfButtonClick()
    {
        Time.timeScale = 0.5f;
    }
    public void OnTimeScaleTwoButtonClick()
    {
        Time.timeScale = 2.0f;
    }
}
