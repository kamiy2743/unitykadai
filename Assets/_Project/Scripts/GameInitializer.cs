using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private DebugCell debugCellPrefab;

    private int[] rawData = new int[]
    {
        1,1,1,1,1,1,1,1,0,1,
        1,0,0,0,0,1,0,0,0,1,
        1,0,1,0,0,0,0,1,1,1,
        1,0,0,1,0,1,0,0,0,1,
        1,0,0,0,0,0,0,1,0,1,
        1,1,0,1,1,0,0,0,0,1,
        1,0,0,0,0,0,0,1,0,1,
        1,1,1,0,1,0,1,0,1,1,
        1,0,0,0,0,0,0,0,0,1,
        1,0,1,1,1,1,1,1,1,1,
    };

    // Start is called before the first frame update
    async void Start()
    {
        var mapData = new MapData(10, 10, rawData);
        var routingSolver = new RoutingSolver(mapData);

        for (int x = 0; x < mapData.Width; x++)
        {
            for (int y = 0; y < mapData.Height; y++)
            {
                if (mapData.GetCell(x, y).CellType == CellType.Wall)
                {
                    var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    go.transform.position = new Vector3(x, 0, mapData.Height - 1 - y);
                }
            }
        }

        var route = await routingSolver.GetShortestRoute(new Vector2Int(1, 9), new Vector2Int(8, 0), debugCellPrefab);
        foreach (var coordinate in route)
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            go.transform.position = new Vector3(coordinate.x, 0, mapData.Height - 1 - coordinate.y);
        }
    }
}
