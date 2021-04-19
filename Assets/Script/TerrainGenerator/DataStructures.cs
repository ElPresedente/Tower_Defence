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
    public double CitadelHealth;
}