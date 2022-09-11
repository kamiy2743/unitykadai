using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameClearScene : MonoBehaviour
{
    [SerializeField] private Transform unitychanParent;
    [SerializeField] private Transform loopStartPos;
    [SerializeField] private Transform loopEndPos;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Button titleButton;
    [SerializeField] private CanvasGroup fadeInUI;
    [SerializeField] private float fadeInDuration;

    void Start()
    {
        titleButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("TItleScene");
        });

        fadeInUI.alpha = 1;
        fadeInUI.DOFade(0, fadeInDuration);
    }

    void Update()
    {
        foreach (Transform unitychan in unitychanParent)
        {
            if (unitychan.position.z > loopEndPos.position.z)
            {
                unitychan.position = new Vector3(unitychan.position.x, unitychan.position.y, loopStartPos.position.z);
            }

            unitychan.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }
}
