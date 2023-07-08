using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ResultsPanelUI : MonoBehaviour
{
    public UnityEvent RetryButtonClicked;

    [SerializeField] private Button _retryButton;

    public void Initialize()
    {
        RetryButtonClicked = _retryButton.onClick;
    }
}