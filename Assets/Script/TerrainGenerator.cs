using System.Collections.Generic;
using UnityEngine;
//using System.Text.Json;

public class TerrainGenerator : MonoBehaviour
{
    [Tooltip("Префаб тайла")]
    public GameObject Tile;
    public GameObject TowerBase;
    [Space()]

    [Tooltip("Материал тайла типа Path")]
    public Material PathMaterial;

    [Tooltip("Материал тайла типа Earth")]
    public Material EarthMaterial;

    [Tooltip("Материал тайла типа Citadel")]
    public Material CitadelMaterial;

    [Tooltip("Материал башни")]
    public Material TowerBaseMaterial;

    private LevelFieldData temp = new LevelFieldData(10, 10);

    public GameObject[,] TilesGOArray;
    [ContextMenu("Create a field")]

    /// <summary>
    /// Функция для создания пустого игрового поля
    /// </summary>
    void CreateField() // old code
    {
        Vector3 position = new Vector3(0, 0, 0);
        Quaternion rotation = new Quaternion(0, 0, 0, 0);
        LevelFieldData data = ReadLevelData();

        for (int i = 0; i < data.y; i += 2)
        {
            for (int j = 0; j < data.x; j++)
            {
                TilesGOArray[i, j] = Instantiate(Tile, position, rotation, transform);
                position += new Vector3(3.4f, 0, 0);
                TilesGOArray[i, j].name = $"Tile {i}{j}";
            }
            position -= new Vector3(position.x, 0, 0);
            position += new Vector3(0, 0, 6);
        }
        position = new Vector3(1.7f, 0, 3);
        for (int i = 1; i < data.y; i += 2)
        {
            for (int j = 0; j < data.x; j++)
            {
                TilesGOArray[i, j] = Instantiate(Tile, position, rotation, transform);
                position += new Vector3(3.4f, 0, 0);
                TilesGOArray[i, j].name = $"Tile {i}{j}";
            }
            position -= new Vector3(position.x -1.7f, 0, 0);
            position += new Vector3(0, 0, 6);
        }
    }
    public void CreateTerrain(LevelFieldData fieldData, bool editMode = false)
    {
        Vector3 position = new Vector3(0, 0, 0);
        Quaternion rotation = new Quaternion(0, 0, 0, 0);
        TilesGOArray = new GameObject[fieldData.x, fieldData.y];

        for (int i = 0; i < fieldData.y; i += 2)
        {
            for (int j = 0; j < fieldData.x; j++)
            {
                TilesGOArray[i, j] = Instantiate(Tile, position, rotation, transform);
                position += new Vector3(3.4f, 0, 0);
                TilesGOArray[i, j].name = $"Tile {i}{j}";
            }
            position -= new Vector3(position.x, 0, 0);
            position += new Vector3(0, 0, 6);
        }
        position = new Vector3(1.7f, 0, 3);
        for (int i = 1; i < fieldData.y; i += 2)
        {
            for (int j = 0; j < fieldData.x; j++)
            {
                TilesGOArray[i, j] = Instantiate(Tile, position, rotation, transform);
                position += new Vector3(3.4f, 0, 0);
                TilesGOArray[i, j].name = $"Tile {i}{j}";
            }
            position -= new Vector3(position.x - 1.7f, 0, 0);
            position += new Vector3(0, 0, 6);
        }
        if (!editMode)
        {
            for (int i = 0; i < fieldData.x; i++)
            {
                for (int j = 0; j < fieldData.y; j++)
                {
                    Debug.Log(i + " " + j + " " + i * fieldData.y + j);
                    SetTileType(fieldData.tileArray[i * fieldData.y + j], TilesGOArray[i, j]);
                }
            }
        }
        
    }
    /// <summary>
    /// первичное определение типов тайлов
    /// </summary>
    //void SetTylesTypes()
    //{
    //    for(int i = 0; i < temp.x; i++)
    //    {
    //        for(int j = 0; j < temp.y; j++)
    //        {
    //            SetTileType(temp.tileArray[i, j], TilesGOArray[i, j]);
    //        }
    //    }
    //}
    /// <summary>
    /// Преобразование тайла в указанный тип
    /// </summary>
    /// <param name="tileType">Новый тип тайла</param>
    /// <param name="gameObject">Объект тайла</param>
    public void SetTileType(TileType tileType, GameObject gameObject, bool editMode = false)
    {
        switch (tileType)
        {
            case TileType.Earth:
                {
                    gameObject.transform.GetChild(0).GetComponent<Renderer>().material = EarthMaterial;
                    gameObject.transform.localScale = new Vector3(0.5f, 1.5f, 0.5f);
                    break;
                }
            case TileType.Path:
                {
                    gameObject.transform.GetChild(0).GetComponent<Renderer>().material = PathMaterial;
                    break;
                }
            case TileType.Citadel:
                {
                    gameObject.transform.GetChild(0).GetComponent<Renderer>().material = CitadelMaterial;
                    gameObject.transform.localScale = new Vector3(0.5f, 5f, 0.5f);
                    gameObject.AddComponent<Citadel>();
                    if (!editMode)
                        StaticGameManager.GameManager.CitadelGO = gameObject;
                    break;
                }
            case TileType.TowerPlace:
                {
                    gameObject.transform.localScale = new Vector3(0.5f, 1.3f, 0.5f);
                    gameObject.transform.GetChild(0).GetComponent<Renderer>().material = TowerBaseMaterial;
                    gameObject.transform.GetChild(0).GetComponent<MeshFilter>().mesh = TowerBase.GetComponent<MeshFilter>().sharedMesh;
                    gameObject.AddComponent<TowerBase>();
                    if(!editMode)
                        StaticGameManager.GameManager.TowersArray.Add(gameObject);
                    break;
                }
        }
    }
    /// <summary>
    /// Чтение информации об уровне из файла
    /// </summary>
    /// <returns></returns>
    LevelFieldData ReadLevelData()
    {
        LevelFieldData levelData;
        /*StreamReader reader = new StreamReader("Assets/Levels/level1.txt");
        string jsonString = reader.ReadLine();
        levelData = JsonSerializer.Deserialize<LevelData>(jsonString);*/
        levelData = temp;
        return levelData;
    }

    //void tempCreateLevelData()
    //{
    //    temp.x = 10;
    //    temp.y = 10;
    //    int[,] tempTileArray = { {1,1,1,1,1,1,1,1,1,1},
    //                             {1,1,1,1,1,1,1,1,1,1},
    //                             {1,1,1,2,2,1,1,2,2,1},
    //                             {1,2,2,4,2,2,2,1,2,2},
    //                             {1,2,1,1,1,1,1,1,1,1},
    //                             {2,1,2,2,2,2,2,1,1,1},
    //                             {1,2,2,1,1,1,1,2,2,1},
    //                             {1,1,1,2,2,1,1,1,2,1},
    //                             {1,2,2,2,1,2,2,2,2,1},
    //                             {3,1,1,1,1,1,1,1,1,1} };
    //    for(int i = 0; i < temp.x; i++)
    //    {
    //        for(int j = 0; j < temp.y; j++)
    //        {
    //            temp.tileArray[i, j] = (TileType)tempTileArray[i, j];
    //        }
    //    }
    //}

    
}
