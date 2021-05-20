using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBase : MonoBehaviour
{
    
    public GameObject tower;
    public bool isTowerPlaced = false;


    [ContextMenu("test spawn tower")]
    public void SpawnTower()
    {
        tower = Instantiate(StaticGameManager.GameManager.Tower, gameObject.transform);
        tower.transform.localScale = new Vector3(1.5f, 0.7f, 1.5f);
        tower.transform.localPosition = new Vector3(0, 0, 0);
        tower.AddComponent<Tower>();
        isTowerPlaced = true;
    }
}
