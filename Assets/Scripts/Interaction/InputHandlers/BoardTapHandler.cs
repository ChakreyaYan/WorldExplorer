﻿using UnityEngine;
using HoloToolkit.Unity.InputModule;
using Assets.Scripts.Plugins;

public class BoardTapHandler : MonoBehaviour, IInputClickHandler
{
    /// <summary>
    /// Handles the users tap on the board itself.
    /// </summary>
    
    private AudioClip clickFeedback;
    private AudioSource audioSource;

    void Start()
    {
        var audioContainer = GameObject.Find("AudioContainer");
        audioSource = audioContainer.GetComponents<AudioSource>()[1];
        clickFeedback = Resources.Load<AudioClip>("Audio/highclick");
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        BoardInteraction.Instance.Tap(SessionManager.Instance.me.CursorLocationToVector2d());
        audioSource.PlayOneShot(clickFeedback, 0.1f);
    }
}
