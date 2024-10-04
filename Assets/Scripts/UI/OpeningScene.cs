using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpeningScene : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] Button exitButton;
    [SerializeField] string startGameSceneName = "InGame";

    void Start()
    {
        startButton.onClick.AddListener(() => StartGame());
        exitButton.onClick.AddListener(() => Application.Quit());
    }

    public void StartGame()
    {
        SceneManager.LoadScene(startGameSceneName);
    }
}
