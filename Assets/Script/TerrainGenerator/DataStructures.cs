public enum TileType
{
    Undefined,
    Earth,
    Path,
    Citadel
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