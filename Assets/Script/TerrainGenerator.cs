using System.IO;
using System.Collections.Generic;
using UnityEngine;
//using System.Text.Json;

public class TerrainGenerator : MonoBehaviour
{
    [Tooltip("������ �����")]
    public GameObject Tile;
    [Space()]
    [Tooltip("�������� ����� ���� Path")]
    public Material PathMaterial;
    [Tooltip("�������� ����� ���� Earth")]
    public Material EarthMaterial;
    [Tooltip("�������� ����� ���� Citadel")]
    public Material CitadelMaterial;

    private LevelData temp = new LevelData(10, 10);

    private GameObject[,] Array = new GameObject[10, 10];
    [ContextMenu("Create a field")]
    void Awake()
    {
        //To do: ������ ���������� �� ������ �� �����
        tempCreateLevelData();
        CreateField();
        
        SetTylesTypes();
    }

    /// <summary>
    /// ������� ��� �������� ������� �������� ����
    /// </summary>
    void CreateField()
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
    }
    /// <summary>
    /// ��������� ����������� ����� ������
    /// </summary>
    void SetTylesTypes()
    {
        for(int i = 0; i < temp.x; i++)
        {
            for(int j = 0; j < temp.y; j++)
            {
                SetTileType(temp.tileArray[i, j].type, Array[i, j]);
            }
        }
    }
    /// <summary>
    /// �������������� ����� � ��������� ���
    /// </summary>
    /// <param name="tileType">����� ��� �����</param>
    /// <param name="gameObject">������ �����</param>
    void SetTileType(TileType tileType, GameObject gameObject)
    {
        switch (tileType)
        {
            case TileType.Earth:
                {
                    gameObject.transform.GetChild(0).GetComponent<Renderer>().material = EarthMaterial;
                    gameObject.transform.localScale = new Vector3((float)0.5, (float)1.5, (float)0.5);
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
                    gameObject.transform.localScale = new Vector3((float)0.5, (float)5, (float)0.5);
                    gameObject.AddComponent<SphereCollider>().radius = 0.6f;
                    gameObject.GetComponent<SphereCollider>().isTrigger = true;
                    gameObject.AddComponent<Rigidbody>();
                    break;
                }
        }
    }
    /// <summary>
    /// ������ ���������� �� ������ �� �����
    /// </summary>
    /// <returns></returns>
    LevelData ReadLevelData()
    {
        LevelData levelData;
        /*StreamReader reader = new StreamReader("Assets/Levels/level1.txt");
        string jsonString = reader.ReadLine();
        levelData = JsonSerializer.Deserialize<LevelData>(jsonString);*/
        levelData = temp;
        return levelData;
    }

    void tempCreateLevelData()
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
                                 {3,1,1,1,1,1,1,1,1,1} };
        for(int i = 0; i < temp.x; i++)
        {
            for(int j = 0; j < temp.y; j++)
            {
                temp.tileArray[i, j] = new TileData((TileType)tempTileArray[i, j]);
            }
        }
    }
}



