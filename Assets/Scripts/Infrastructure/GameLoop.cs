using Duck;
using UnityEngine;

//Этот класс является циклом игры. У него есть 
public class GameLoop : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;

    private DuckFactory _duckFactory;
    private DuckContainer _playerDuck;
    private GameLoopUI _ui;

    public void Initialize(GameLoopUI ui, DuckFactory duckFactory)
    {
        _ui = ui;
        _duckFactory = duckFactory;
    }

    //Этот метод будет вызван 1 раз, чтобы начать игровой цикл, в нашем случае это будет показ меню, катсцена
    public void Begin()
    {
        _ui.gameObject.SetActive(false);
        _playerDuck = _duckFactory.CreateDuck(_spawnPoint.position);
        _playerDuck.Health.Died += Lose;
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