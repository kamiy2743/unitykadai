using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapViewer : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private float size;
    [SerializeField] private float scale;
    [SerializeField] private Transform entityParent;
    [SerializeField] private Transform player;
    [SerializeField] private Transform enemy;
    [SerializeField] private Transform pathParent;
    [SerializeField] private Transform pathPrefab;

    private PlayerMover _playerMover;
    private EnemyMover _enemyMover;

    public void StartInitial(MapData mapData, PlayerMover playerMover, EnemyMover enemyMover)
    {
        _playerMover = playerMover;
        _enemyMover = enemyMover;

        for (int x = 0; x < MapData.Width; x++)
        {
            for (int y = 0; y < MapData.Height; y++)
            {
                var id = mapData.GetCellID(x, MapData.Height - 1 - y);
                if (id == 0)
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
        var enemyPos = ToMapPos(_enemyMover.transform.position);

        player.localPosition = playerPos;
        enemy.localPosition = enemyPos;

        entityParent.localPosition = -playerPos;
        pathParent.localPosition = -playerPos;

        parent.rotation = Quaternion.Euler(0, 0, _playerMover.RotateY);
    }

    private Vector2 ToMapPos(Vector3 position)
    {
        return new Vector2(position.x / MapObjectConstructor.StageScale - 0.5f, position.z / MapObjectConstructor.StageScale - 0.5f);
    }
}
