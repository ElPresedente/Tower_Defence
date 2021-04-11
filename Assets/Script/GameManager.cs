using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] PathArray;

    public GameObject EnemyObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    [ContextMenu("test spawn enemy")]
    public void SpawnEnemy()
    {
        Instantiate(EnemyObject, PathArray[0].position, Quaternion.Euler(new Vector3(0, 0, 0)), transform);
    }
}
