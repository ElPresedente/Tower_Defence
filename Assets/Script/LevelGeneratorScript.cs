using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelGeneratorScript : MonoBehaviour
{
    [Header("Ссылки на необходимые компоненты")]
    [Tooltip("Объект с компонентом Terrain Generator")]
    public GameObject TerrainGeneratorGO;
    [Tooltip("Префаб врага (не используется)")]
    public int Enemytype;

    [Space()]
    [Header("Информация об уровне (заполнить до генерации тайлов)")]
    [Tooltip("Колическтво тайлов по вертикали")]
    public int length;
    [Tooltip("Количество тайлов по горизонтали")]
    public int width;
    [Tooltip("Враги пойдут по указанным тайлам, цитадель также должна входить в путь!")]
    public List<Transform> EnemiesPath;

    [Space()]
    [Header("Характеристики врагов в волнах")]
    [Tooltip("Количество врагов в волнах")]
    public List<int> NumberOfEnemiesInWave;
    [Tooltip("Количество здоровья у врагов НА ОДНОЙ ВОЛНЕ")]
    public List<double> EnemiesHealth;
    [Tooltip("Количество урона у врагов НА ОДНОЙ ВОЛНЕ")]
    public List<double> EnemiesDamage;
    [Tooltip("Скорость передвижения у врагов НА ОДНОЙ ВОЛНЕ")]
    public List<float> EnemiesMovementSpeed;
    [Tooltip("Количество золота за убийство врага НА ОДНОЙ ВОЛНЕ")]
    public List<int> EnemiesGold;

    [Space()]
    [Header("Остальные характеристики")]
    [Tooltip("Здоровье цитадели")]
    public double CitadelHealth;
    [Space()]
    public string FileName;


    private LevelFieldData levelFieldData;
    //Он ДОЛЖЕН сэкономить кучу времени
    [ContextMenu("Generate Map to choose tile types")]
    public void GenerateMap()
    {
        TerrainGenerator terrainGenerator = TerrainGeneratorGO.GetComponent<TerrainGenerator>();
        levelFieldData = new LevelFieldData(length, width);
        terrainGenerator.CreateTerrain(levelFieldData, true);
        for (int i = 0; i < levelFieldData.x; i++)
        {
            for(int j = 0; j < levelFieldData.y; j++)
            {
                terrainGenerator.TilesGOArray[i, j].AddComponent<TilesSelectorScript>().TerrainGenerator = TerrainGeneratorGO;
                terrainGenerator.TilesGOArray[i, j].GetComponent<TilesSelectorScript>().tileType = TileType.Earth;
                terrainGenerator.TilesGOArray[i, j].GetComponent<TilesSelectorScript>().LevelGeneratorScript = gameObject;
                terrainGenerator.SetTileType(TileType.Earth, terrainGenerator.TilesGOArray[i, j]);
            }
        }
    }
    [ContextMenu("Save tiles types")]
    public void GetTilesData()
    {
        TerrainGenerator terrainGenerator = TerrainGeneratorGO.GetComponent<TerrainGenerator>();
        for (int i = 0; i < levelFieldData.x; i++)
        {
            for(int j = 0; j < levelFieldData.y; j++)
            {
                levelFieldData.tileArray[i* levelFieldData.y + j] = terrainGenerator.TilesGOArray[i, j].GetComponent<TilesSelectorScript>().tileType;
            }
        }
        Debug.Log(levelFieldData.tileArray[5].ToString());
    }
    [ContextMenu("Save level data")]
    public void SaveData()
    {
        List<Vector3> enemyPath = new List<Vector3>();
        for(int i = 0; i < EnemiesPath.Count; i++)
        {
            enemyPath.Add(EnemiesPath[i].position);
        }

        List<EnemyData> enemiesWaves = new List<EnemyData>();
        for(int i = 0; i < NumberOfEnemiesInWave.Count; i++)
        {
            for(int j = 0; j < NumberOfEnemiesInWave[i]; j++)
            {
                enemiesWaves.Add(new EnemyData(EnemyType.Simple, EnemiesHealth[i], EnemiesMovementSpeed[i], EnemiesDamage[i], EnemiesGold[i]));
            }
        }

        StreamWriter write = new StreamWriter(File.Open("Assets\\Levels\\" + FileName, FileMode.OpenOrCreate));
        LevelData levelData = new LevelData(NumberOfEnemiesInWave.Count, enemyPath.Count, enemiesWaves.Count, width, length);
        for(int i = 0; i < enemyPath.Count; i++)
        {
            levelData.EnemyPath[i] = enemyPath[i];
        }
        for(int i = 0; i < enemiesWaves.Count; i++)
        {
            levelData.EnemiesWaves[i] = enemiesWaves[i];
        }
        for(int i = 0; i < NumberOfEnemiesInWave.Count; i++)
        {
            levelData.NumberOfEnemiesInWave[i] = NumberOfEnemiesInWave[i];
        }
        levelData.FieldData = levelFieldData;
        Debug.Log(levelData.FieldData.tileArray[2].ToString());
        levelData.CitadelHealth = CitadelHealth;
        string test = JsonUtility.ToJson(levelData, true);
        Debug.Log(test);
        write.WriteLine(test);
        write.Close();

        LevelData testt = JsonUtility.FromJson<LevelData>(test);
        Debug.Log(testt.FieldData.tileArray[2].ToString());
    }
}
