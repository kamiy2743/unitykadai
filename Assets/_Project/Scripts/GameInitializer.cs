using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private MapObjectConstructor mapObjectConstructor;
    [SerializeField] private PlayerMover playerMover;
    [SerializeField] private EnemyMover enemyMoverPrefab;
    [SerializeField] private MapViewer mapViewer;

    // Start is called before the first frame update
    void Start()
    {
        var mapData = new MapData();
        mapObjectConstructor.StartInitial(mapData);

        playerMover.StartInitial(ToPosition(mapData.PlayerStartCoordinate));

        var routingSolver = new RoutingSolver(mapData);

        var enemyMovers = new List<EnemyMover>();
        foreach (var coordinate in mapData.EnemyStartCoordinates)
        {
            var enemyMover = Instantiate(enemyMoverPrefab);
            enemyMover.StartInitial(ToPosition(coordinate), playerMover, routingSolver);
            enemyMovers.Add(enemyMover);
        }

        mapViewer.StartInitial(mapData, playerMover, enemyMovers);
    }

    private Vector3 ToPosition(Vector2Int coordinate)
    {
        return new Vector3(coordinate.x * MapObjectConstructor.StageScale + 0.5f, 1, coordinate.y * MapObjectConstructor.StageScale + 0.5f);
    }
}
