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
            gameObject.transform.localScale = new Vector3((float)0.5, (float)1.5, (float)0.5);
        }
        else
        {
            gameObject.transform.GetChild(0).GetComponent<Renderer>().material = grassType;
        }
        
    }

    
}
public enum TileType
{
    Undefined,
    Earth,
    Path
}
