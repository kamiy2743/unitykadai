using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Legacy
{
    public class Cell
    {
        public readonly Vector2Int Coordinate;
        public readonly CellType CellType;

        public Cell(Vector2Int coordinate, CellType cellType)
        {
            Coordinate = coordinate;
            CellType = cellType;
        }
    }
}
