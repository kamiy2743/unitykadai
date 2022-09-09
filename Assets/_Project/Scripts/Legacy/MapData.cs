using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Legacy
{
    public class MapData
    {
        public readonly int Width;
        public readonly int Height;

        private Cell[] cells;

        public MapData(int width, int height, int[] rawData)
        {
            Width = width;
            Height = height;

            cells = new Cell[width * height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var cellID = rawData[ToIndex(x, y)];
                    cells[ToIndex(x, y)] = new Cell(new Vector2Int(x, y), (CellType)cellID);
                }
            }
        }

        public Cell GetCell(int x, int y)
        {
            return cells[ToIndex(x, y)];
        }

        private int ToIndex(int x, int y)
        {
            return Width * y + x;
        }
    }
}
