using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UiInputManager : MonoBehaviour
{
    public static UiInputManager instance;

    public VisualTreeAsset startView;
    public VisualTreeAsset highScore;
    public VisualTreeAsset settingsView;

    private HighscoreHelper HighscoreHelper;
    private StartViewHelper StartViewHelper;
    private SettingsViewHelper SettingsViewHelper;


    private void Awake()
    {
        Singleton();
        UIDocument uIDocument = GetComponent<UIDocument>();
        HighscoreHelper = new(highScore, uIDocument);
        StartViewHelper = new(startView, uIDocument);
        SettingsViewHelper = new(settingsView, uIDocument);

        ShowStart();

    }

    public void ShowStart()
    {
        StartViewHelper.ShowStart();
    }
    public void ShowSettings()
    {
        StartViewHelper.HideStart();
        SettingsViewHelper.ShowSettings();
    }

    public void ShowHighscore()
    {
        StartViewHelper.HideStart();
        HighscoreHelper.ShowHighscore();
    }

    public void StartGame()
    {
        //Start Your Game here
    }

    public void LeaveGame()
    {
        Debug.Log("Leaving Game");
        Application.Quit();
    }

    public void SetPlayer(string playerName) => StartViewHelper.SetPlayer(playerName);

    public void SetScore(string score) => StartViewHelper.SetScore(score);

    private void Singleton()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
}
