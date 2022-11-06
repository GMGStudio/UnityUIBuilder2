using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StartViewHelper : MonoBehaviour
{
    private Button StartButton;
    private Button HighscoreButton;
    private Button SettingsButton;
    private Button LeaveButton;
    private TextField playerNameInput;
    private Label playerNameLabel;
    private Label scoreLabel;

    private VisualElement UIPopUp;

    private string playerName;

    private VisualTreeAsset view;
    private VisualElement viewRoot;
    private UIDocument uIDocument;

    public StartViewHelper(VisualTreeAsset view, UIDocument uIDocument)
    {
        this.view = view;
        this.uIDocument = uIDocument;
    }

    public void ShowStart()
    {
        uIDocument.visualTreeAsset = view;
        viewRoot = uIDocument.rootVisualElement;
        viewRoot.visible = true;
        StartButton = viewRoot.Q<Button>("StartGame");
        HighscoreButton = viewRoot.Q<Button>("Highscore");
        SettingsButton = viewRoot.Q<Button>("Settings");
        LeaveButton = viewRoot.Q<Button>("LeaveGame");
        playerNameInput = viewRoot.Q<TextField>("playerNameInput");
        UIPopUp = viewRoot.Q<VisualElement>("UIPopUp");
        playerNameLabel = viewRoot.Q<Label>("PlayerName");
        scoreLabel = viewRoot.Q<Label>("Score");

        SetPlayer(playerName);


        StartButton.clicked += UiInputManager.instance.StartGame;
        HighscoreButton.clicked += UiInputManager.instance.ShowHighscore;
        LeaveButton.clicked += UiInputManager.instance.LeaveGame;
        SettingsButton.clicked += UiInputManager.instance.ShowSettings;
    }

    public void HideStart()
    {
        StartButton.clicked -= UiInputManager.instance.StartGame;
        HighscoreButton.clicked -= UiInputManager.instance.ShowHighscore;
        LeaveButton.clicked -= UiInputManager.instance.LeaveGame;
        SettingsButton.clicked -= UiInputManager.instance.ShowSettings;
        viewRoot.visible = false;
    }

    public void SetPlayer(string playerName)
    {
        playerNameLabel.text = playerName;
    }

    public void SetScore(string score)
    {
        scoreLabel.text = score;
    }
}
