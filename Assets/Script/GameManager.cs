using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [Tooltip("Путь противников по клеткам")]
    public Transform[] PathArray;
    [Tooltip("Объект противника")]
    public GameObject EnemyObject;
    [Tooltip("Список установленных башен")]
    public List<GameObject> TowersArray;
    [Tooltip("Объект башни")]
    public GameObject Tower;
    [Tooltip("Объект пули")]
    public GameObject Bullet;
    [Space()]
    [Header("Волны и все про волны")]
    [Tooltip("Очередь противников в текущей волне")]
    public Queue<EnemyData> QueueOfEnemies;
    [Tooltip("Задержка между волнами врагов")]
    [Range(0, 10)]
    public float NextWaveCooldown;
    private float TimeForNextWave;
    [Tooltip("Задержка перед спавном следующего врага")]
    [Range(0f, 5f)]
    public float NextEnemySpawnDelay;
    private float TimeForNextEnemySpawn;
    private int EnemiesInCurrentWave;
    public List<int> EnemiesInWaves;

    public int NumberOfWaves;
    private int CurrentWaveNumber = 0;

    private bool isCitadelLive = true;


    private void Awake()
    {
        StaticGameManager.GameManager = gameObject.GetComponent<GameManager>();
        TimeForNextWave = NextWaveCooldown;
        TimeForNextEnemySpawn = StaticGameManager.TimeForNextEnemy;
        QueueOfEnemies = new Queue<EnemyData>();
        for(int i = 0; i < 5 * NumberOfWaves; i++)
        {
            QueueOfEnemies.Enqueue(new EnemyData(EnemyObject));
        }
    }
    private void Update()
    {
        if(EnemiesInCurrentWave == 0)
        {
            TimeForNextWave -= Time.deltaTime;
        }
        else if(TimeForNextWave <= 0)
        {
            CurrentWaveNumber++;
            EnemiesInCurrentWave = EnemiesInWaves[CurrentWaveNumber];
        }
        else
        {
            if(TimeForNextEnemySpawn <= 0)
            {
                SpawnEnemy(QueueOfEnemies.Dequeue());
                TimeForNextEnemySpawn = NextEnemySpawnDelay;
            }
            else
            {
                TimeForNextEnemySpawn -= Time.deltaTime;
            }
        }
    }

    void Start()
    {
        StaticGameManager.ReadPathFromFile();
    }

    [ContextMenu("test spawn enemy")]
    public void SpawnEnemy(EnemyData enemyData)
    {
        GameObject Enemy = Instantiate(EnemyObject, StaticGameManager.VectorPath[0], Quaternion.Euler(new Vector3(0, 0, 0)), transform);
        Enemy enemyComponent = Enemy.AddComponent<Enemy>();
        enemyComponent.EnemyData = enemyData;
    }

    [ContextMenu("save path")]
    void SavePathToFile()
    {
        StreamWriter write = new StreamWriter(File.Open("Assets\\Levels\\level1.dat", FileMode.OpenOrCreate));
        JsonStruct testsd = new JsonStruct(StaticGameManager.VectorPath);
        string test = JsonUtility.ToJson(testsd);
        Debug.Log(test);
        write.WriteLine(test);
        write.Close();
        Debug.Log("suckcessful D:\\test\\TowerDefence\\Assets\\Scripts\\templevel.dat ");
    }

    public void OnCitadelDie()
    {
        isCitadelLive = false;
    }
}


