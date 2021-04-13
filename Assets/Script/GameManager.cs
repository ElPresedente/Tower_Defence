using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;


public class GameManager : MonoBehaviour
{
    public Transform[] PathArray;

    public Vector3[] VectorPath;

    public GameObject EnemyObject;

    public List<GameObject> TowersArray;

    public GameObject Tower;

    void Start()
    {
        ReadPathFromFile();
    }

    // Update is called once per frame
    void Update()
    {

    }
    [ContextMenu("test spawn enemy")]
    public void SpawnEnemy()
    {
        Instantiate(EnemyObject, VectorPath[0], Quaternion.Euler(new Vector3(0, 0, 0)), transform);
    }

    [ContextMenu("save path")]
    void SavePathToFile()
    {
        StreamWriter write = new StreamWriter(File.Open("D:\\test\\TowerDefence\\Assets\\Scripts\\templevel.dat", FileMode.OpenOrCreate));
        VectorPath = new Vector3[PathArray.Length];
        for(int i = 0; i < PathArray.Length; i++)
        {
            VectorPath[i] = PathArray[i].position;
        }
        string test = JsonUtility.ToJson(new JsonStruct(VectorPath));
        Debug.Log(test);
        write.WriteLine(test);
        write.Close();
        Debug.Log("suckcessful D:\\test\\TowerDefence\\Assets\\Scripts\\templevel.dat " +PathArray[0].position.x );
    }
    void ReadPathFromFile()
    {
        StreamReader read = new StreamReader(File.Open("D:\\test\\TowerDefence\\Assets\\Scripts\\templevel.dat", FileMode.Open));
        string jsonData = read.ReadToEnd();
        JsonStruct data = JsonUtility.FromJson<JsonStruct>(jsonData);
        VectorPath = data.VectorPath;
    }
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
