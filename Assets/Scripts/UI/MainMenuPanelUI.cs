using System;
using UnityEngine;
using UnityEngine.UI;

internal class MainMenuPanelUI : MonoBehaviour
{
    public event Action PlayPressed;
    
    [SerializeField] private Button _playButton;

    private void Start()
    {
        _playButton.onClick.AddListener(PressPlay);
    }

    private void PressPlay()
    {
        PlayPressed?.Invoke();
    }
}