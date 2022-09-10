using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapData
{
    public static int Width { get; private set; }
    public static int Height { get; private set; }

    private int[] cellIDs;

    public MapData(int width, int height, int[] rawData)
    {
        Width = width;
        Height = height;

        cellIDs = new int[width * height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var cellID = rawData[ToIndex(x, y)];
                cellIDs[ToIndex(x, y)] = cellID;
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
