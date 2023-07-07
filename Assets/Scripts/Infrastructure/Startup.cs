using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startup : MonoBehaviour
{
    [SerializeField] private InputService _inputService;
    [SerializeField] private GameLoop _gameLoop;
    
    // Start is called before the first frame update
    void Start()
    {
        _gameLoop.Initialize(_inputService);
        _gameLoop.Begin();
    }
}