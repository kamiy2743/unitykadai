using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RoutingSolver
{
    private MapData _mapData;

    public RoutingSolver(MapData mapData)
    {
        _mapData = mapData;
    }

    public List<Vector2Int> GetShortestRoute(Vector2Int start, Vector2Int goal)
    {
        var startCell = new AgentCell(start, 0, null);
        var goalCell = GetGoalCellRecursive(startCell, goal, 0, new List<AgentCell>(), new List<Vector2Int>() { start });
        return GetRoute(goalCell);
    }

    /// <returns>GoalCell</returns>
    private AgentCell GetGoalCellRecursive(AgentCell current, Vector2Int goal, int step, List<AgentCell> heads, List<Vector2Int> searchedCoordinates)
    {
        var coordinates = new Vector2Int[]
        {
            current.Coordinate + Vector2Int.up,
            current.Coordinate + Vector2Int.right,
            current.Coordinate + Vector2Int.down,
            current.Coordinate + Vector2Int.left,
        };

        // 四方向の隣接セルのWeightを計算
        foreach (var coordinate in coordinates)
        {
            if (searchedCoordinates.Contains(coordinate)) continue;
            if (coordinate.x < 0 || coordinate.x >= _mapData.Width) continue;
            if (coordinate.y < 0 || coordinate.y >= _mapData.Height) continue;
            if (_mapData.GetCellID(coordinate.x, coordinate.y) == 1) continue;

            var distance = Mathf.Pow(goal.x - coordinate.x, 2) + Mathf.Pow(goal.y - coordinate.y, 2);
            var weight = (step + 1) + distance;

            var agentCell = new AgentCell(coordinate, weight, current);
            heads.Add(agentCell);
        }

        // 探索済みに追加
        searchedCoordinates.AddRange(coordinates);

        // weightが一番低いセル取得
        var softestCell = heads.OrderBy(x => x.Weight).ToArray()[0];
        if (softestCell.Coordinate == goal)
        {
            return softestCell;
        }

        // weightが一番低いセルから探索再開
        heads.Remove(softestCell);

        return GetGoalCellRecursive(softestCell, goal, step + 1, heads, searchedCoordinates);
    }

    private List<Vector2Int> GetRoute(AgentCell goalCell)
    {
        var route = new List<Vector2Int>();
        Recursive(goalCell, route);
        return route;

        void Recursive(AgentCell current, List<Vector2Int> route)
        {
            route.Add(current.Coordinate);
            if (current.Previous == null) return;
            Recursive(current.Previous, route);
        }
    }

    private class AgentCell
    {
        public Vector2Int Coordinate;
        public readonly float Weight;
        public readonly AgentCell Previous;

        public AgentCell(Vector2Int coordinate, float weight, AgentCell previous)
        {
            Coordinate = coordinate;
            Weight = weight;
            Previous = previous;
        }
    }
}
