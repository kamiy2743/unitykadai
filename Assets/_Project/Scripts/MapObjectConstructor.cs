using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObjectConstructor : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private GameObject floorPrefab;
    [SerializeField] private GameObject ceilPrefab;

    public const float StageScale = 2;

    public void StartInitial(MapData mapData)
    {
        var floor = Instantiate(floorPrefab);
        floor.transform.SetParent(parent);
        floor.transform.position = new Vector3(MapData.Width * 0.5f * StageScale, 0, MapData.Height * 0.5f * StageScale);
        floor.transform.localScale = new Vector3(MapData.Width * 0.1f * StageScale, 1, MapData.Height * 0.1f * StageScale);

        var ceil = Instantiate(ceilPrefab);
        ceil.transform.SetParent(parent);
        ceil.transform.position = new Vector3(MapData.Width * 0.5f * StageScale, StageScale, MapData.Height * 0.5f * StageScale);
        ceil.transform.localScale = new Vector3(MapData.Width * 0.1f * StageScale, 1, MapData.Height * 0.1f * StageScale);

        for (int x = 0; x < MapData.Width; x++)
        {
            for (int y = 0; y < MapData.Height; y++)
            {
                if (mapData.GetCellID(x, y) == 1)
                {
                    var wall = Instantiate(wallPrefab);
                    wall.transform.SetParent(parent);
                    wall.transform.position = new Vector3(x, 0, MapData.Height - 1 - y) * StageScale + Vector3.one * 0.5f * StageScale;
                    wall.transform.localScale = Vector3.one * StageScale;
                }
            }
        }
    }
}
