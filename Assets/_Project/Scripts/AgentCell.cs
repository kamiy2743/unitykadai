using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentCell
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
