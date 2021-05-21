using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public static class StaticGameManager
{
    public static int Gold = 100;

    public static float TimeForNextEnemy = 2.5f;

    public static float BulletSpeed = 100;
    //TODO: effects

    public static Vector3[] VectorPath;

    public static GameManager GameManager;

    public static double[] TowerLevelDamage =  {100, 108.5, 115, 123.5, 130, 
                                                140, 150  , 160, 170  , 180, 
                                                195, 210  , 225, 250  , 275 };
    public static double[] TowerLevelFireSpeed = {100, 100, 100, 100, 100,
                                                  120, 120, 120, 120, 120,
                                                  140, 140, 140, 140, 140};
    public static int TowerCost = 100;
    public static int[] TowerUpgradeCost = {100, 150, 200, 250, 300,
                                            350, 400, 450, 500, 550,
                                            600, 650, 700, 750, 800};

    public static string levelDataFileName = "level1.dat";

    public static GameObject EnemyTypeToGameObject(EnemyType enemyType)
    {
        switch (enemyType)
        {
            case EnemyType.Simple:
                {
                    return GameManager.EnemyObject;
                }
            default:
                {
                    return GameManager.EnemyObject;
                }
        }
    }
}