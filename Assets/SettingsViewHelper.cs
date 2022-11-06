using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SettingsViewHelper : MonoBehaviour
{

    private Toggle muteAudioToggle;
    private Slider mainVolume;
    private Button backButton;

    private VisualTreeAsset view;
    private VisualElement viewRoot;
    private UIDocument uIDocument;

    public SettingsViewHelper(VisualTreeAsset view, UIDocument uIDocument)
    {
        this.view = view;
        this.uIDocument = uIDocument;
    }

    public void ShowSettings()
    {
        uIDocument.visualTreeAsset = view;
        viewRoot = uIDocument.rootVisualElement;
        viewRoot.visible = true;
        muteAudioToggle = viewRoot.Q<Toggle>("MuteAudio");
        mainVolume = viewRoot.Q<Slider>("Volume");
        backButton = viewRoot.Q<Button>("Back");
        backButton.clicked += BackToStartView;

        muteAudioToggle.RegisterValueChangedCallback(OnMuteAudioToggle);
        mainVolume.RegisterValueChangedCallback(OnVolumechange);
    }

    private void OnVolumechange(ChangeEvent<float> evt)
    {
        Debug.Log("Volume" + evt.newValue);
    }

    private void OnMuteAudioToggle(ChangeEvent<bool> evt)
    {
        Debug.Log("Toogle" + evt.newValue);
    }

    private void BackToStartView()
    {
        viewRoot.visible = false;

        backButton.clicked -= BackToStartView;
        UiInputManager.instance.ShowStart();
    }
}
