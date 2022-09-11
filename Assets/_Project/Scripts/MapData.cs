using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapData
{
    public const int Width = 30;
    public const int Height = 30;

    private int[] cellIDs = new int[Width * Height];

    public Vector2Int PlayerStartCoordinate { get; private set; }
    public List<Vector2Int> EnemyStartCoordinates { get; private set; } = new List<Vector2Int>();

    public MapData()
    {
        var csv = Resources.Load<TextAsset>("MapData").text;
        var lines = csv.Split(System.Environment.NewLine);
        for (int y = 0; y < Height; y++)
        {
            var ids = lines[y].Split(",");
            for (int x = 0; x < Width; x++)
            {
                var id = int.Parse(ids[x]);
                cellIDs[ToIndex(x, y)] = int.Parse(ids[x]);

                if (id == 2)
                {
                    PlayerStartCoordinate = new Vector2Int(x, y);
                }

                if (id == 3)
                {
                    EnemyStartCoordinates.Add(new Vector2Int(x, y));
                }
            }
        }
    }

    public int GetCellID(int x, int y)
    {
        return cellIDs[ToIndex(x, y)];
    }

    private int ToIndex(int x, int y)
    {
        return Width * y + x;
    }
}
