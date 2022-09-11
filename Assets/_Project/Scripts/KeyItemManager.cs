using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItemManager : MonoBehaviour
{
    [SerializeField] private GameObject keyItemPrefab;

    public void StartInitial(List<Vector3> startPositions)
    {
        foreach (var position in startPositions)
        {
            var keyItem = Instantiate(keyItemPrefab, transform);
            keyItem.transform.position = position;
        }
    }
}
