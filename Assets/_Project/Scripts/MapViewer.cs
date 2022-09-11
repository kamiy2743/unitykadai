using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapViewer : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private Transform entityParent;
    [SerializeField] private Transform player;
    [SerializeField] private Transform enemyPrefab;
    [SerializeField] private Transform pathParent;
    [SerializeField] private Transform pathPrefab;

    private PlayerMover _playerMover;
    private List<EnemyMover> _enemyMovers;

    private List<Transform> enemies = new List<Transform>();

    public void StartInitial(MapData mapData, PlayerMover playerMover, List<EnemyMover> enemyMovers)
    {
        _playerMover = playerMover;
        _enemyMovers = enemyMovers;

        foreach (var enemyMover in _enemyMovers)
        {
            var enemy = Instantiate(enemyPrefab, entityParent);
            enemies.Add(enemy);
        }

        for (int x = 0; x < MapData.Width; x++)
        {
            for (int y = 0; y < MapData.Height; y++)
            {
                var id = mapData.GetCellID(x, MapData.Height - 1 - y);
                if (id != 1)
                {
                    var path = Instantiate(pathPrefab, pathParent);
                    path.localPosition = new Vector2(x, y);
                }
            }
        }
    }

    void Update()
    {
        var playerPos = ToMapPos(_playerMover.transform.position);
        player.localPosition = playerPos;

        for (int i = 0; i < _enemyMovers.Count; i++)
        {
            var enemyPos = ToMapPos(_enemyMovers[i].transform.position);
            enemies[i].localPosition = enemyPos;
        }

        entityParent.localPosition = -playerPos;
        pathParent.localPosition = -playerPos;

        parent.rotation = Quaternion.Euler(0, 0, _playerMover.RotateY);
    }

    private Vector2 ToMapPos(Vector3 position)
    {
        return new Vector2(position.x / MapObjectConstructor.StageScale - 0.5f, position.z / MapObjectConstructor.StageScale - 0.5f);
    }
}
