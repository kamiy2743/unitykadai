using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Cysharp.Threading.Tasks;

public class GameClearScene : MonoBehaviour
{
    [SerializeField] private Transform unitychanParent;
    [SerializeField] private Transform loopStartPos;
    [SerializeField] private Transform loopEndPos;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Button titleButton;
    [SerializeField] private CanvasGroup fadeInUI;
    [SerializeField] private float fadeInDuration;

    async void Start()
    {
        titleButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("TItleScene");
        });

        fadeInUI.alpha = 1;
        await fadeInUI.DOFade(0, fadeInDuration);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
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
