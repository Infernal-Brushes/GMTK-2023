using System;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.Events;

public class GameLoopUI : MonoBehaviour
{
    public event Action Retry;
    
    [SerializeField] private ResultsPanelUI _losePanelUI;
    [SerializeField] private ResultsPanelUI _winPanelUI;

    public void Initialize()
    {
        _losePanelUI.Initialize();
        _winPanelUI.Initialize();
        _losePanelUI.RetryButtonClicked.AddListener(RetryClicked);
        _winPanelUI.RetryButtonClicked.AddListener(RetryClicked);
    }

    public void ShowResultsPanel(bool won)
    {
        _winPanelUI.gameObject.SetActive(won);
        _losePanelUI.gameObject.SetActive(!won);
    }

    private void RetryClicked()
    {
        Retry?.Invoke();
    }
}