using System;
using System.Collections;
using UnityEngine;

public class GameLoopUI : MonoBehaviour
{
    public event Action Retry;
    
    [SerializeField] private ResultsPanelUI _losePanelUI;
    [SerializeField] private ResultsPanelUI _winPanelUI;
    [SerializeField] private AudioSource _mainMusic;
    [SerializeField] private AudioSource _gameOverSound;
    [SerializeField] private AudioSource _gameOverMusic;
    
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
        _mainMusic.Stop();
        StartCoroutine(PlayGameOverMusic());
    }

    private IEnumerator PlayGameOverMusic()
    {
        _gameOverSound.Play();
        yield return new WaitForSeconds(_gameOverSound.clip.length);
        _gameOverMusic.Play();
    }
    
    private void RetryClicked()
    {
        Retry?.Invoke();
    }
}