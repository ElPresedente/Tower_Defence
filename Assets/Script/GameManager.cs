using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;


public class GameManager : MonoBehaviour
{
    public Transform[] PathArray;

    public GameObject EnemyObject;

    public List<GameObject> TowersArray;

    public GameObject Tower;

    public GameObject Bullet;

    private void Awake()
    {
        StaticGameManager.GameManager = gameObject.GetComponent<GameManager>();
    }

    void Start()
    {
        StaticGameManager.ReadPathFromFile();
    }

    [ContextMenu("test spawn enemy")]
    public void SpawnEnemy()
    {
        GameObject Enemy = Instantiate(EnemyObject, StaticGameManager.VectorPath[0], Quaternion.Euler(new Vector3(0, 0, 0)), transform);
        Enemy.AddComponent<Enemy>();
    }

    [ContextMenu("save path")]
    void SavePathToFile()
    {
        StreamWriter write = new StreamWriter(File.Open("D:\\test\\TowerDefence\\Assets\\Scripts\\templevel.dat", FileMode.OpenOrCreate));
        StaticGameManager.VectorPath = new Vector3[PathArray.Length];
        for(int i = 0; i < PathArray.Length; i++)
        {
            StaticGameManager.VectorPath[i] = PathArray[i].position;
        }
        string test = JsonUtility.ToJson(new JsonStruct(StaticGameManager.VectorPath));
        Debug.Log(test);
        write.WriteLine(test);
        write.Close();
        Debug.Log("suckcessful D:\\test\\TowerDefence\\Assets\\Scripts\\templevel.dat " +PathArray[0].position.x );
    }
    
}


