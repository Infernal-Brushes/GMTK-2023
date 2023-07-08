using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Duck;
using GMTK2023.Enemy;
using UnityEngine;

//Этот класс является энтипоинтом для захода в игру, здесь происходит инициализация игры, чтобы её запустить
public class Startup : MonoBehaviour
{
    [SerializeField] private InputService _inputService;
    [SerializeField] private GameLoop _gameLoop;
    [SerializeField] private DuckFactory _duckFactory;
    [SerializeField] private GameLoopUI _gameLoopUI;
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    
    
    void Start()
    {
        _duckFactory.Initialize(_inputService);
        _gameLoopUI.Initialize();
        _gameLoop.Initialize(_virtualCamera, _gameLoopUI, _duckFactory);
        _gameLoop.Begin();
    }
}
