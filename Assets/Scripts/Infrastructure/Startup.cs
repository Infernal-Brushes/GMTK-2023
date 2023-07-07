using System.Collections;
using System.Collections.Generic;
using GMTK2023.Enemy;
using UnityEngine;

public class Startup : MonoBehaviour
{
    [SerializeField] private InputService _inputService;
    [SerializeField] private GameLoop _gameLoop;
    [SerializeField] private DuckContainer _duckContainer;
    
    // Start is called before the first frame update
    void Start()
    {
        _duckContainer.Initialize(_inputService);
        _gameLoop.Initialize(_inputService);
        _gameLoop.Begin();
    }
}