using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    private Button startButton;
    private Button settingsButton;
    private Button achivementsButton;
    private Button quitButton;

    private void OnEnable()
    {
        UIDocument uIDocument = GetComponent<UIDocument>();
        VisualElement root = uIDocument.rootVisualElement;

        startButton = root.Q<Button>("PlayButton");
        settingsButton = root.Q<Button>("SettingButton");
        achivementsButton = root.Q<Button>("AchivementsButton");
        quitButton = root.Q<Button>("QuitButton");

        startButton.clicked += StartGame;
        settingsButton.clicked += ShowSettings;
        achivementsButton.clicked += ShowAchivements;
        quitButton.clicked += QuitGame;
    }

    private void StartGame()
    {
        
    }
    private void ShowSettings()
    {

    }

    private void ShowAchivements()
    {

    }

    private void QuitGame()
    {
        Application.Quit();
    }
    private void OnDisable()
    {
        startButton.clicked -= StartGame;
        settingsButton.clicked -= ShowSettings;
        achivementsButton.clicked -= ShowAchivements;
        quitButton.clicked -= QuitGame;
    }
}
