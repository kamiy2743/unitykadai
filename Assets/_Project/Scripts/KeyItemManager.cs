using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItemManager : MonoBehaviour
{
    [SerializeField] private PlayerDetector keyItemPrefab;

    public List<GameObject> KeyItems = new List<GameObject>();

    private int keyItemCount;

    public void StartInitial(List<Vector3> startPositions)
    {
        foreach (var position in startPositions)
        {
            keyItemCount += 1;
            var keyItem = Instantiate(keyItemPrefab, transform);
            keyItem.transform.position = position;
            keyItem.OnDetect.AddListener(() => OnGet(keyItem.gameObject));
            KeyItems.Add(keyItem.gameObject);
        }
    }

    private void OnGet(GameObject keyItem)
    {
        keyItem.SetActive(false);
        keyItemCount -= 1;
        if (keyItemCount <= 0)
        {
            Debug.Log("clear");
        }
    }
}
