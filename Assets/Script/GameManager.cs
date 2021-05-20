using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [Tooltip("������ ����������")]
    public GameObject EnemyObject;
    [Tooltip("������ ������������� �����")]
    public List<GameObject> TowersArray;
    [Tooltip("������ �����")]
    public GameObject Tower;
    [Tooltip("������ ����")]
    public GameObject Bullet;
    [Space()]
    [Header("����� � ��� ��� �����")]
    [Tooltip("�������� ����� ������� ������")]
    [Range(0, 10)]
    public float NextWaveCooldown;
    private float TimeForNextWave;
    [Tooltip("�������� ����� ������� ���������� �����")]
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
        //��������� ������ �� ������������� �������
        StaticGameManager.GameManager = gameObject.GetComponent<GameManager>();
        terrainGeneraror = TerrainGeneratorGO.GetComponent<TerrainGenerator>();
        //�������� �������� ��� �������� ���� ������
        TimeForNextWave = NextWaveCooldown;
        TimeForNextEnemySpawn = StaticGameManager.TimeForNextEnemy;
        //�������� ������ ������
        StreamReader read = new StreamReader(File.Open("Assets\\Levels\\LEVELDATA.dat", FileMode.Open));
        string json = read.ReadToEnd();
        levelData = JsonUtility.FromJson<LevelData>(json);
        //�������� �������� ����
        StaticGameManager.VectorPath = levelData.EnemyPath;
        terrainGeneraror.CreateTerrain(levelData.FieldData);
        //���������� ������� ������
        QueueOfEnemies = new Queue<EnemyData>(levelData.EnemiesWaves.Length);
        for (int i = 0; i < levelData.EnemiesWaves.Length; i++)
        {
            QueueOfEnemies.Enqueue(levelData.EnemiesWaves[i]);
        }
        //��������� ���� �����
        StaticGameManager.VectorPath = levelData.EnemyPath;

        NumberOfWaves = levelData.NumberOfEnemiesInWave.Length;
        //��������� ����� ������
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


