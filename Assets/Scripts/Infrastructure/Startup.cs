using Cinemachine;
using Duck;
using UnityEngine;

//Этот класс является энтипоинтом для захода в игру, здесь происходит инициализация игры, чтобы её запустить
public class Startup : MonoBehaviour
{
    [SerializeField] private InputService _inputService;
    [SerializeField] private GameVictory _victory;
    [SerializeField] private GameLoop _gameLoop;
    [SerializeField] private DuckFactory _duckFactory;
    [SerializeField] private GameLoopUI _gameLoopUI;
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    
    private void Start()
    {
        _duckFactory.Initialize(_inputService);
        _gameLoopUI.Initialize();
        _gameLoop.Initialize(_virtualCamera, _gameLoopUI, _duckFactory);
        _victory.Initialize(_gameLoop);
        _gameLoop.Begin();
    }
}
