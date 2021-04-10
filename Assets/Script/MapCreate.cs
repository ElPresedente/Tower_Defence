using System.IO;
using System.Collections.Generic;
using UnityEngine;
//using System.Text.Json;

public class MapCreate : MonoBehaviour
{
    public GameObject Tile;

    public LevelData temp = new LevelData(10, 10);

    public GameObject[,] Array = new GameObject[10, 10];
    // Start is called before the first frame update
    void Start()
    {
        tempCreateLevelData();
        CreateField();
        Array[1, 3].GetComponent<TileTypeChange>().SetTileType(TileType.Earth);
        //Array[1, 3].GetComponent<Renderer>().material.SetColor("test", new Color(0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateField()
    {
        Vector3 position = new Vector3(0, 0, 0);
        Quaternion rotation = new Quaternion(0, 0, 0, 0);
        LevelData data = ReadLevelData();


        for (int i = 0; i < data.y; i += 2)
        {
            for (int j = 0; j < data.x; j++)
            {
                Array[i, j] = Instantiate(Tile, position, rotation, transform);
                position += new Vector3(3.4f, 0, 0);
                Array[i, j].name = $"Tile {i}{j}";
            }
            position -= new Vector3(position.x, 0, 0);
            position += new Vector3(0, 0, 6);
        }
        position = new Vector3(1.7f, 0, 3);
        for (int i = 1; i < data.y; i += 2)
        {
            for (int j = 0; j < data.x; j++)
            {
                Array[i, j] = Instantiate(Tile, position, rotation, transform);
                position += new Vector3(3.4f, 0, 0);
                Array[i, j].name = $"Tile {i}{j}";
            }
            position -= new Vector3(position.x -1.7f, 0, 0);
            position += new Vector3(0, 0, 6);
        }
        SetTylesTypes();
    }

    void SetTylesTypes()
    {
        for(int i = 0; i < temp.x; i++)
        {
            for(int j = 0; j < temp.y; j++)
            {
                Array[i, j].GetComponent<TileTypeChange>().SetTileType(temp.tileArray[i, j].type);
            }
        }
    }
    public LevelData ReadLevelData()
    {
        LevelData levelData;
        /*StreamReader reader = new StreamReader("Assets/Levels/level1.txt");
        string jsonString = reader.ReadLine();
        levelData = JsonSerializer.Deserialize<LevelData>(jsonString);*/
        levelData = temp;
        return levelData;
    }

    public void tempCreateLevelData()
    {
        temp.x = 10;
        temp.y = 10;
        int[,] tempTileArray = { {1,1,1,1,1,1,1,1,1,1},
                                 {1,1,1,1,1,1,1,1,1,1},
                                 {1,1,1,2,2,1,1,2,2,1},
                                 {1,2,2,1,2,2,2,1,2,2},
                                 {1,2,1,1,1,1,1,1,1,1},
                                 {2,1,2,2,2,2,2,1,1,1},
                                 {1,2,2,1,1,1,1,2,2,1},
                                 {1,1,1,2,2,1,1,1,2,1},
                                 {1,2,2,2,1,2,2,2,2,1},
                                 {2,1,1,1,1,1,1,1,1,1} };
        for(int i = 0; i < temp.x; i++)
        {
            for(int j = 0; j < temp.y; j++)
            {
                temp.tileArray[i, j] = new TileData((TileType)tempTileArray[i, j]);
            }
        }
    }
}
public struct LevelData
{
    public int x;
    public int y;
    public TileData[,] tileArray;
    public LevelData(int x, int y)
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


