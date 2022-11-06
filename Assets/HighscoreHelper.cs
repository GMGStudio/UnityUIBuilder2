using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HighscoreHelper : MonoBehaviour
{

    private ListView highscoreList;
    private Button highscoreBack;


    private VisualElement ViewRoot;
    private VisualTreeAsset highScore;
    private UIDocument uIDocument;

    public HighscoreHelper(VisualTreeAsset highScore, UIDocument uIDocument)
    {
        this.highScore = highScore;
        this.uIDocument = uIDocument;
    }
    private void InitializeHighscoreView()
    {

        uIDocument.visualTreeAsset = highScore;

        ViewRoot = uIDocument.rootVisualElement;
        ViewRoot.visible = true;
        highscoreList = ViewRoot.Q<ListView>("HighscoreList");
        highscoreBack = ViewRoot.Q<Button>("Back");
        highscoreBack.clicked += BackToStartView;
    }

    public void ShowHighscore()
    {

        InitializeHighscoreView();
        var itemsSource = GameController.instance.GetHighscore();

        VisualElement makeItem()
        {
            GroupBox box = new();

            box.AddToClassList("highscoreGroup");
            Label label = new();
            label.AddToClassList("highscoreLabel");
            box.Add(label);

            Label label2 = new();
            label2.AddToClassList("highscoreScore");
            box.Add(label2);
            return box;
        }
        Action<VisualElement, int> bindItem = (element, i) =>
        {
            GroupBox box = (element as GroupBox);
            (box.ElementAt(0) as Label).text = itemsSource[i].Player;
            (box.ElementAt(1) as Label).text = itemsSource[i].Score.ToString();
        };
        highscoreList.makeItem = makeItem;
        highscoreList.bindItem = bindItem;
        highscoreList.itemsSource = itemsSource;
    }

    private void BackToStartView()
    {
        ViewRoot.visible = false;

        highscoreBack.clicked -= BackToStartView;
        UiInputManager.instance.ShowStart();
    }
}
