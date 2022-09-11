using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Cysharp.Threading.Tasks;

public class GameClearManager : MonoBehaviour
{
    [SerializeField] private PlayerMover playerMover;
    [SerializeField] private CanvasGroup fadeOutUI;
    [SerializeField] private float fadeOutDuration;

    public void StartInitial()
    {
        fadeOutUI.alpha = 0;
    }

    public async void GameClear()
    {
        playerMover.Dispose();
        await fadeOutUI.DOFade(1, fadeOutDuration);
        SceneManager.LoadScene("GameClearScene");
    }
}
