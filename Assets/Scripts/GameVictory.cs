using System;
using Statistics;
using UnityEngine;

public class GameVictory : MonoBehaviour
{
    [SerializeField] private Score _score;
    [SerializeField] private bool _isActive;
   
    private GameLoop _gameLoop;

    public void Initialize(GameLoop gameLoop)
    {
        _gameLoop = gameLoop ?? throw new ArgumentNullException(nameof(gameLoop));
    }
    
    private void Update()
    {
        if (_score.Count == 0 && !_isActive)
        {
            _gameLoop.Won();
            _isActive = true;
        }
    }
}