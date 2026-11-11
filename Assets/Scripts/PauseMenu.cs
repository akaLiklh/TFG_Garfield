using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{
    private VisualElement root;
    private Button restartButton;
    private Button resumeButton;
    private Button exitMenuButton;

    private bool paused;

    private void OnEnable()
    {
        UIDocument uIDocument = GetComponent<UIDocument>();
        root = uIDocument.rootVisualElement;

        restartButton = root.Q<Button>("RestartButton");
        resumeButton = root.Q<Button>("ResumeButton");
        exitMenuButton = root.Q<Button>("ExitMenuButton");

        restartButton.clicked += ReStartGame;
        resumeButton.clicked += PlayGame;
        exitMenuButton.clicked += ExitMenuButton;

        root.style.display = DisplayStyle.None;
    }

    private void ReStartGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void PlayGame()
    {
        paused = false;
        Time.timeScale = 1f;
        root.style.display = DisplayStyle.None;
    }

    private void ExitMenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); 
    }
    private void OnDisable()
    {
        restartButton.clicked -= ReStartGame;
        resumeButton.clicked -= PlayGame;
        exitMenuButton.clicked -= ExitMenuButton;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused) PlayGame();             // Osea si pulsas escape, vas al menu de pausa y luego vuelves a pausar escape volvera al juego.
            else Pause();
        }
    }
    private void Pause()
    {
        paused = true;
        Time.timeScale = 0f;
        root.style.display = DisplayStyle.Flex;
    }
}