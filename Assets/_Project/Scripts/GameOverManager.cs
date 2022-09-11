using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private EnemyDetector enemyDetector;
    [SerializeField] private GameObject ui;
    [SerializeField] private Button continueButton;

    // Start is called before the first frame update
    void Start()
    {
        ui.SetActive(false);

        enemyDetector.OnDetect.AddListener(GameOver);
        continueButton.onClick.AddListener(Continue);
    }

    private void GameOver()
    {
        ui.SetActive(true);
    }

    private void Continue()
    {
        SceneManager.LoadScene("PlayScene");
    }
}
