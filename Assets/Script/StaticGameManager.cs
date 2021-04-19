using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public static class StaticGameManager
{
    public static int Gold = 100;

    public static double TowerDamage = 100;
    public static double TowerFireSpeed = 120;
    public static float BulletSpeed = 100;

    public static double EnemyHealth = 500;
    public static float EnemyMovementSpeed = 10;
    public static double EnemyDamage = 250;
    public static int EnemyGold = 25;

    public static float TimeForNextEnemy = 2.5f;

    public static double CitadelHealth = 1000;
    //TODO: effects

    public static Vector3[] VectorPath;

    public static GameManager GameManager;

    public static void ReadPathFromFile()
    {
        StreamReader read = new StreamReader(File.Open("Assets\\Levels\\level1.dat", FileMode.Open));
        string jsonData = read.ReadToEnd();
        JsonStruct data = JsonUtility.FromJson<JsonStruct>(jsonData);
        VectorPath = data.VectorPath;
    }
}
