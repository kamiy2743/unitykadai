using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapViewer : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private Transform entityParent;
    [SerializeField] private Transform player;
    [SerializeField] private Transform enemyPrefab;
    [SerializeField] private Transform keyItemPrefab;
    [SerializeField] private Transform pathParent;
    [SerializeField] private Transform pathPrefab;

    private PlayerMover _playerMover;

    private List<EnemyMover> _enemyMovers;
    private List<Transform> enemies = new List<Transform>();

    private List<GameObject> _keyItems;
    private List<GameObject> keyItemViews = new List<GameObject>();

    public void StartInitial(MapData mapData, PlayerMover playerMover, List<EnemyMover> enemyMovers, List<GameObject> keyItems)
    {
        _playerMover = playerMover;
        _enemyMovers = enemyMovers;
        _keyItems = keyItems;

        foreach (var enemyMover in _enemyMovers)
        {
            var enemy = Instantiate(enemyPrefab, entityParent);
            enemies.Add(enemy);
        }

        foreach (var keyItem in keyItems)
        {
            var keyItemView = Instantiate(keyItemPrefab, entityParent);
            keyItemView.localPosition = ToMapPos(keyItem.transform.position);
            keyItemViews.Add(keyItemView.gameObject);
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

        for (int i = 0; i < _keyItems.Count; i++)
        {
            keyItemViews[i].SetActive(_keyItems[i].activeSelf);
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
