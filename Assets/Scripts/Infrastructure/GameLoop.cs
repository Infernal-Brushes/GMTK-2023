using Cinemachine;
using Duck;
using UnityEngine;

//Этот класс является циклом игры. У него есть 
public class GameLoop : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private WavesLoop _wavesLoop;
    
    private DuckFactory _duckFactory;
    private DuckContainer _playerDuck;
    private GameLoopUI _ui;
    private CinemachineVirtualCamera _virtualCamera;

    public void Initialize(CinemachineVirtualCamera virtualCamera, GameLoopUI ui, DuckFactory duckFactory)
    {
        _ui = ui;
        _virtualCamera = virtualCamera;
        _duckFactory = duckFactory;
    }

    //Этот метод будет вызван 1 раз, чтобы начать игровой цикл, в нашем случае это будет показ меню, катсцена
    public void Begin()
    {
        _ui.gameObject.SetActive(false);
        _playerDuck = _duckFactory.CreateDuck(_spawnPoint.position);
        _wavesLoop.Initialize(_playerDuck.transform);
        _playerDuck.Health.Died += Lose;
        _virtualCamera.Follow = _playerDuck.transform;
        _virtualCamera.LookAt = _playerDuck.transform;
    }

    private void Lose()
    {
        _ui.gameObject.SetActive(true);
        _ui.ShowResultsPanel(false);
        Destroy(_playerDuck.gameObject);
    }

    private void Won()
    {
        _ui.gameObject.SetActive(true);
        _ui.ShowResultsPanel(true);
    }
}