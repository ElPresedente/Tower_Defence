using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileTypeChange : MonoBehaviour
{
    public Material earthType;
    public Material grassType;

    private TileType currentType = 0;

    TileType GetCurrentType()
    {
        return currentType;
    }
    public void SetTileType(TileType tileType)
    {
        currentType = tileType;
        if(tileType == TileType.Earth)
        {
            gameObject.transform.GetChild(0).GetComponent<Renderer>().material = earthType;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material = grassType;
        }
        
    }

    
}
public enum TileType
{
    Undefined,
    Earth,
    Grass
}
