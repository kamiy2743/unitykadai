using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private MapObjectConstructor mapObjectConstructor;
    [SerializeField] private PlayerMover playerMover;
    [SerializeField] private EnemyMover enemyMover;

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
    void Start()
    {
        // var mapData = new MapData(10, 10, rawData);
        var mapData = new MapData(20, 20, new int[400]);
        mapObjectConstructor.StartInitial(mapData);

        var routingSolver = new RoutingSolver(mapData);
        enemyMover.StartInitial(playerMover, routingSolver);
    }
}
