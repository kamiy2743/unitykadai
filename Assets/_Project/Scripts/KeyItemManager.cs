using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyItemManager : MonoBehaviour
{
    [SerializeField] private PlayerDetector keyItemPrefab;
    [SerializeField] private TMP_Text itemCountUI;

    public List<GameObject> KeyItems = new List<GameObject>();

    private int maxItemCount;
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

        maxItemCount = keyItemCount;
        SetText();
    }

    private void OnGet(GameObject keyItem)
    {
        keyItem.SetActive(false);
        keyItemCount -= 1;
        SetText();

        if (keyItemCount <= 0)
        {
            Debug.Log("clear");
        }
    }

    private void SetText()
    {
        itemCountUI.text = $"封印を解くカギ: {maxItemCount - keyItemCount} / {maxItemCount}";
    }
}
