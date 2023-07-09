using Cinemachine;
using Duck;
using Statistics;
using UnityEngine;

//Этот класс является циклом игры. У него есть 
public class GameLoop : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private WavesLoop _wavesLoop;
    [SerializeField] private Score _score;
    [SerializeField] private GameObject _menuScreen;
    [SerializeField] private GameObject _gameScreen;
    
    private DuckFactory _duckFactory;
    private DuckContainer _playerDuck;
    private GameLoopUI _ui;
    private CinemachineVirtualCamera _virtualCamera;
    private bool _started;
    
    public void Initialize(CinemachineVirtualCamera virtualCamera, GameLoopUI ui, DuckFactory duckFactory)
    {
        _ui = ui;
        _virtualCamera = virtualCamera;
        _duckFactory = duckFactory;
        _ui.Play += Begin;
        _ui.Retry += Retry;
    }

    //Этот метод будет вызван 1 раз, чтобы начать игровой цикл, в нашем случае это будет показ меню, катсцена
    private void Begin()
    {
        _started = true;
        _ui.gameObject.SetActive(false);
        _menuScreen.SetActive(false);
        _gameScreen.SetActive(true);
        _playerDuck = _duckFactory.CreateDuck(_spawnPoint.position);
        _wavesLoop.Initialize(_playerDuck.transform);
        _score.Initialize(_playerDuck.Health);
        _playerDuck.Health.Died += Lose;
        _virtualCamera.Follow = _playerDuck.transform;
        _virtualCamera.LookAt = _playerDuck.transform;
    }

    private void Update()
    {
        if(!_started)
            return;
        
        if(_score.Count == 0)
            Won();
    }

    private void Lose()
    {
        _started = false;
        _ui.gameObject.SetActive(true);
        _ui.ShowResultsPanel(false);
        _playerDuck.gameObject.SetActive(false);
        _wavesLoop.StopWaves();
    }

    private void Retry()
    {
        _started = false;
        _menuScreen.SetActive(true);
        _gameScreen.SetActive(false);
    }

    private void Won()
    {
        _started = false;
        _ui.gameObject.SetActive(true);
        _ui.ShowResultsPanel(true);
        _wavesLoop.StopWaves();
    }
}