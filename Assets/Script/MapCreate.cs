using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class MapCreate : MonoBehaviour
{
    public GameObject Tile;
    public int x;
    public int y;

    public GameObject[,] Array = new GameObject[10, 10];
    // Start is called before the first frame update
    void Start()
    {
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
        StreamReader reader = new StreamReader("Assets/Levels/level1.txt");
        int[,] array = new int[10,10];

        for(int i = 0; i < 10; i++)
        {
            for(int j = 0; j < 10; j++)
            {
                array[i, j] = reader.Read();
            }
        }

        for (int i = 0; i < y; i += 2)
        {
            for (int j = 0; j < x; j++)
            {
                Array[i, j] = Instantiate(Tile, position, rotation, transform);
                position += new Vector3((float)3.4, 0, 0);
                Array[i, j].name = $"Tile {i}{j}";
            }
            position -= new Vector3(position.x, 0, 0);
            position += new Vector3(0, 0, 6);
        }
        position = new Vector3((float)1.7, 0, 3);
        for (int i = 1; i < y; i += 2)
        {
            for (int j = 0; j < x; j++)
            {
                Array[i, j] = Instantiate(Tile, position, rotation, transform);
                position += new Vector3((float)3.4, 0, 0);
                Array[i, j].name = $"Tile {i}{j}";
            }
            position -= new Vector3(position.x + (float)-1.7, 0, 0);
            position += new Vector3(0, 0, 6);
        }
    }
}
