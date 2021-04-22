using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesSelectorScript : MonoBehaviour
{
    public GameObject TerrainGenerator;
    public GameObject LevelGeneratorScript;
    public TileType tileType = TileType.Earth;
    [ContextMenu("Set Earth type")]
    public void SetEarth()
    {
        TerrainGenerator.GetComponent<TerrainGenerator>().SetTileType(TileType.Earth, gameObject);
        tileType = TileType.Earth;
    }
    [ContextMenu("Set Path type")]
    public void SetPath()
    {
        TerrainGenerator.GetComponent<TerrainGenerator>().SetTileType(TileType.Path, gameObject);
        tileType = TileType.Path;
        LevelGeneratorScript.GetComponent<LevelGeneratorScript>().EnemiesPath.Add(gameObject.transform);
    }
    [ContextMenu("Set TowerPlace type")]
    public void SetTowerPlace()
    {
        TerrainGenerator.GetComponent<TerrainGenerator>().SetTileType(TileType.TowerPlace, gameObject);
        tileType = TileType.TowerPlace;
    }
    [ContextMenu("Set Citadel type")]
    public void SetCitadel()
    {
        TerrainGenerator.GetComponent<TerrainGenerator>().SetTileType(TileType.Citadel, gameObject);
        tileType = TileType.Citadel;
        LevelGeneratorScript.GetComponent<LevelGeneratorScript>().EnemiesPath.Add(gameObject.transform);
    }
}
