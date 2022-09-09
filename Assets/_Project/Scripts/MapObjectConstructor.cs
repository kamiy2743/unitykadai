using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObjectConstructor : MonoBehaviour
{
    private const float StageScale = 2;

    public void StartInitial(MapData mapData)
    {
        var floor = GameObject.CreatePrimitive(PrimitiveType.Plane);
        floor.transform.position = new Vector3(mapData.Width * 0.5f * StageScale, 0, mapData.Height * 0.5f * StageScale);
        floor.transform.localScale = new Vector3(mapData.Width * 0.1f * StageScale, 1, mapData.Height * 0.1f * StageScale);

        for (int x = 0; x < mapData.Width; x++)
        {
            for (int y = 0; y < mapData.Height; y++)
            {
                if (mapData.GetCellID(x, y) == 1)
                {
                    var wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    wall.transform.position = new Vector3(x, 0, mapData.Height - 1 - y) * StageScale + Vector3.one * 0.5f * StageScale;
                    wall.transform.localScale = Vector3.one * StageScale;
                }
            }
        }
    }
}
