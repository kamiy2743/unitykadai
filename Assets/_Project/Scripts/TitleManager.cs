using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField] private Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        startButton.onClick.AddListener(GoPlayScene);
    }

    private void GoPlayScene()
    {
        SceneManager.LoadScene("PlayScene");
    }
}
