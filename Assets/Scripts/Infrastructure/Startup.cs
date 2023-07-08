using System.Collections;
using System.Collections.Generic;
using Duck;
using GMTK2023.Enemy;
using UnityEngine;

//Этот класс является энтипоинтом для захода в игру, здесь происходит инициализация игры, чтобы её запустить
public class Startup : MonoBehaviour
{
    [SerializeField] private InputService _inputService;
    [SerializeField] private GameLoop _gameLoop;
    [SerializeField] private DuckFactory _duckFactory;
    [SerializeField] private PistolAimsFactory _pistolAimsFactory;
    
    void Start()
    {
        _duckFactory.Initialize(_inputService);
        _gameLoop.Initialize(_duckFactory);
        _gameLoop.Begin();
    }
}