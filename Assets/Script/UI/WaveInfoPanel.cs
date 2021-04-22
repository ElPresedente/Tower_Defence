//using UnityEngine;
//using TMPro;
//using UnityEngine.UI;
//public class WaveInfoPanel : MonoBehaviour
//{
//    // GameManager уровня
//    public GameManager GM;
//    [Header("Информация о волнах")]
//    [Tooltip("Отображает номер текущей волны и количество волн на уровне")]
//    public TMP_Text WaveCounterLabel;
//    [Tooltip("Шкала, показывающая, как быстро наступит следующая волна")]
//    public Image NextWaveProgressBar;
//    [Tooltip("Показывает, сколько секунд осталось до начала следующей волны")]
//    public TMP_Text NextWaveTimer;

//    // Время начала следующей волны
//    private float nextWaveStartTime;
//    private int totalWaveNumber;
//    public void Awake()
//    {
//        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
//        totalWaveNumber = GM.TotalWaveNumber;
//        NextWaveProgressBar.fillAmount = 1;
//    }
//    public void Update()
//    {
//        int currentWaveNumber = GM.CurrentWaveNumber;
//        nextWaveStartTime = GM.TimeForNextWaveStart;
//        WaveCounterLabel.text = string.Format("{0}/{1}", currentWaveNumber, totalWaveNumber);
//        float percantage = 1.0f - (nextWaveStartTime - Time.time) / GM.NextWaveCooldown;
//        NextWaveProgressBar.fillAmount = percantage;
//        NextWaveTimer.text = string.Format("{0}", (int)nextWaveStartTime - (int)Time.time);
//    }

//}
