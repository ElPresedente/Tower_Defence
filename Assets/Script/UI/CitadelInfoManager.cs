using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class CitadelInfoManager : MonoBehaviour
{
    [Space]
    [Header("Информация о цитадели игрока")]
    public TMP_Text CitadelHPLabel;
    public Image citadelInfoPanel;
    public GameObject playerCitadel;
    

    [Space]
    [Header("Цвета панели в зависимости от текущего уровня здоровья цитадели")]
    [Tooltip("Цвет панели, когда уровень здоровья башни в пределах 80-100% от максимального")]
    public Color HP80_100PercentageColor;
    [Tooltip("Цвет панели, когда уровень здоровья башни в пределах 60-80% от максимального")]
    public Color HP60_80PercentageColor;
    [Tooltip("Цвет панели, когда уровень здоровья башни в пределах 40-60% от максимального")]
    public Color HP40_60PercentageColor;
    [Tooltip("Цвет панели, когда уровень здоровья башни в пределах 20-40% от максимального")]
    public Color HP20_40PercentageColor;
    [Tooltip("Цвет панели, когда уровень здоровья башни в пределах 0-20% от максимального")]
    public Color HP0_20PercentageColor;

    private void Start()
    {
        playerCitadel = GameObject.FindGameObjectsWithTag("Citadel")[0];
    }
    public void UpdateCitadelHPInfo(float currentCitadelHP, float maxCitadelHP)
    {
        int percentage = (int)((currentCitadelHP / maxCitadelHP) * 100);
        if((80 <= percentage) && (percentage <=100))
        {
            citadelInfoPanel.color = HP80_100PercentageColor;
        }
        else if((60 <= percentage) && (percentage <= 80))
        {
            citadelInfoPanel.color = HP60_80PercentageColor;
        }
        else if((40 <= percentage) && (percentage <=60))
        {
            citadelInfoPanel.color = HP40_60PercentageColor;
        }
        else if((20 <= percentage) && (percentage <=40))
        {
            citadelInfoPanel.color = HP20_40PercentageColor;
        }
        else if((0 <=percentage) && (percentage <=20))
        {
            citadelInfoPanel.color = HP0_20PercentageColor;
        }
        CitadelHPLabel.text = currentCitadelHP.ToString();
    }
}
