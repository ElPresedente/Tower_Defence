using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;


public class GameManager : MonoBehaviour
{
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
    [Tooltip("Задержка между волнами врагов")]
    [Range(0, 10)]
    public float NextWaveCooldown;
    private float TimeForNextWave;
    [Tooltip("Задержка перед спавном следующего врага")]
    [Range(0f, 5f)]
    public float NextEnemySpawnDelay;
    private float TimeForNextEnemySpawn;
    public int CurrentWaveNumber = 0;
    public int EnemiesInCurrentWave;
    public int NumberOfWaves;

    private LevelData levelData;
    private Queue<EnemyData> QueueOfEnemies;

    public GameObject TerrainGeneratorGO;
    private TerrainGenerator terrainGeneraror;

    public int Gold
    {
        get => _gold;
        set
        {
            _gold = value;
            LevelUI.GetComponent<LevelUIController>().UpdateGameStat();
        }
    }
    private int _gold;
    public GameObject LevelUI;
    public GameObject CitadelGO;


    private void Awake()
    {
        //настройка ссылок на нестатические объекты
        StaticGameManager.GameManager = gameObject.GetComponent<GameManager>();
        terrainGeneraror = TerrainGeneratorGO.GetComponent<TerrainGenerator>();
        //исходные значения для созжания волн врагов
        TimeForNextWave = NextWaveCooldown;
        TimeForNextEnemySpawn = StaticGameManager.TimeForNextEnemy;
        //загрузка данных уровня
        StreamReader read = new StreamReader(File.Open("Assets\\Levels\\LEVELDATA.dat", FileMode.Open));
        string json = read.ReadToEnd();
        levelData = JsonUtility.FromJson<LevelData>(json);
        //Создание игрового поля
        StaticGameManager.VectorPath = levelData.EnemyPath;
        terrainGeneraror.CreateTerrain(levelData.FieldData);
        //заполнение очереди врагов
        QueueOfEnemies = new Queue<EnemyData>(levelData.EnemiesWaves.Length);
        for (int i = 0; i < levelData.EnemiesWaves.Length; i++)
        {
            QueueOfEnemies.Enqueue(levelData.EnemiesWaves[i]);
        }
        //установка пути мобов
        StaticGameManager.VectorPath = levelData.EnemyPath;

        NumberOfWaves = levelData.NumberOfEnemiesInWave.Length;
        //Стартовая сумма золота
        Gold = StaticGameManager.Gold;
    }
    private void Update()
    {
        if(CurrentWaveNumber > NumberOfWaves)
        {
            return;
        }
        //Debug.Log(TimeForNextEnemySpawn);
        if (TimeForNextWave <= 0)
        {
            CurrentWaveNumber++;
            EnemiesInCurrentWave = levelData.NumberOfEnemiesInWave[CurrentWaveNumber - 1];
            TimeForNextWave = NextWaveCooldown;
        }
        else if(EnemiesInCurrentWave == 0)
        {
            TimeForNextWave -= Time.deltaTime;
        }
        else
        {
            if(TimeForNextEnemySpawn <= 0)
            {
                SpawnEnemy(QueueOfEnemies.Dequeue());
                TimeForNextEnemySpawn = NextEnemySpawnDelay;
                EnemiesInCurrentWave--;
            }
            else
            {
                TimeForNextEnemySpawn -= Time.deltaTime;
            }
        }
    }

    [ContextMenu("test spawn enemy")]
    public void SpawnEnemy(EnemyData enemyData)
    {
        //Debug.Log("Spawned");
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
        //Debug.Log(test);
        write.WriteLine(test);
        write.Close();
        //Debug.Log("suckcessful D:\\test\\TowerDefence\\Assets\\Scripts\\templevel.dat ");
    }

    public void OnCitadelDie()
    {

    }
}


