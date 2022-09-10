using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private PlayerMover _playerMover;
    private RoutingSolver _routingSolver;
    private float elapsed;

    public void StartInitial(PlayerMover playerMover, RoutingSolver routingSolver)
    {
        _playerMover = playerMover;
        _routingSolver = routingSolver;
    }

    void Update()
    {
        if (elapsed > 0.5f)
        {
            elapsed = 0;
            var start = new Vector2Int(Mathf.FloorToInt(transform.position.x * MapObjectConstructor.StageScale), MapData.Height - 1 - Mathf.FloorToInt(transform.position.z * MapObjectConstructor.StageScale));
            var route = _routingSolver.GetShortestRoute(start, _playerMover.Coordinate);
            if (route.Count == 0) return;
            var nextPosition = new Vector2(route[0].x, MapData.Height - 1 - route[0].y) + Vector2.one * 0.5f * MapObjectConstructor.StageScale;
            transform.position = new Vector3(nextPosition.x, 1, nextPosition.y);
        }
        else
        {
            elapsed += Time.deltaTime;
        }
    }
}
