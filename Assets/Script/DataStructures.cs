using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;


[Serializable]
public enum TileType
{
    Undefined,
    Earth,
    Path,
    Citadel,
    TowerPlace
}

[Serializable]
public enum EnemyType
{
    undefined,
    Simple
}

[Serializable]
public struct TileData
{
    public TileType type;
    // etc
    public TileData(TileType type_)
    {
        type = type_;
    }
}

[Serializable]
public struct LevelFieldData
{
    public int x;
    public int y;
    public TileType[] tileArray;
    public LevelFieldData(int x, int y)
    {
        this.x = x;
        this.y = y;
        tileArray = new TileType[x * y];
    }
}

[Serializable]
public struct EnemyData
{
    public EnemyData(EnemyType enemyType)
    {
        EnemyType = enemyType;
        EnemyHealth = 500;
        EnemyMovementSpeed = 10;
        EnemyDamage = 250;
        EnemyGold = 25;
    }
    public EnemyData(EnemyType enemyType, double enemyHealth, float emenyMovement, double enemyDamage, int enemyGold)
    {
        EnemyType = enemyType;
        EnemyHealth = enemyHealth;
        EnemyMovementSpeed = emenyMovement;
        EnemyDamage = enemyDamage;
        EnemyGold = enemyGold;
    }
    public EnemyType EnemyType;
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
    public EnemyData[] EnemiesWaves;
    public int[] NumberOfEnemiesInWave;
    public double CitadelHealth;
    public LevelData(int numberOfWaves, int vectorLength, int numberOfEnemies, int x, int y)
    {
        EnemiesWaves = new EnemyData[numberOfEnemies];
        EnemyPath = new Vector3[vectorLength];
        NumberOfEnemiesInWave = new int[numberOfWaves];
        FieldData = new LevelFieldData(x, y);
        CitadelHealth = 0;
    }
}

[Serializable]
public enum SelectedDifficulty
{
    Easy,
    Normal,
    Hard
}