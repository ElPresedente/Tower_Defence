using UnityEngine;
using System;
using System.Collections.Generic;

public enum TileType
{
    Undefined,
    Earth,
    Path,
    Citadel,
    TowerPlace
}
public struct LevelFieldData
{
    public int x;
    public int y;
    public TileData[,] tileArray;
    public LevelFieldData(int x, int y)
    {
        this.x = x;
        this.y = y;
        tileArray = new TileData[x, y];
    }
}

public struct TileData
{
    public TileType type;
    // etc
    public TileData(TileType type_)
    {
        type = type_;
    }
}

public struct EnemyData
{
    public EnemyData(GameObject enemyPrefab)
    {
        EnemyPrefab = enemyPrefab;
        EnemyHealth = 500;
        EnemyMovementSpeed = 10;
        EnemyDamage = 250;
        EnemyGold = 25;
    }
    public EnemyData(GameObject enemyPrefab, double enemyHealth, float emenyMovement, double enemyDamage, int enemyGold)
    {
        EnemyPrefab = enemyPrefab;
        EnemyHealth = enemyHealth;
        EnemyMovementSpeed = emenyMovement;
        EnemyDamage = enemyDamage;
        EnemyGold = enemyGold;
    }
    public GameObject EnemyPrefab;
    public double EnemyHealth;
    public float EnemyMovementSpeed;
    public double EnemyDamage;
    public int EnemyGold;
}

[Serializable]
public struct JsonStruct
{
    public Vector3[] VectorPath;
    public JsonStruct(Vector3[] array)
    {
        this.VectorPath = array;
    }
}

[Serializable]
public struct LevelData
{
    public Vector3[] EnemyPath;
    public LevelFieldData FieldData;
    public Queue<EnemyData> EnemiesWaves;
    public List<int> NumberOfEnemiesInWave;
    public double CitadelHealth;
    public LevelData(Vector3[] enemyPath, LevelFieldData fieldData, Queue<EnemyData> enemiesWaves, List<int> numberOfEnemiesInWaves, double citadelHealth)
    {
        EnemyPath = enemyPath;
        FieldData = fieldData;
        EnemiesWaves = enemiesWaves;
        NumberOfEnemiesInWave = numberOfEnemiesInWaves;
        CitadelHealth = citadelHealth;
    }
}

public enum SelectedDifficulty
{
    Easy,
    Normal,
    Hard
}