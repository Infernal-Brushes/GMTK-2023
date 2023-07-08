using Duck;
using UnityEngine;

//Этот класс является циклом игры. У него есть 
public class GameLoop : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;

    private DuckFactory _duckFactory;
    private DuckContainer _playerDuck;

    public void Initialize(DuckFactory duckFactory)
    {
        _duckFactory = duckFactory;
    }

    //Этот метод будет вызван 1 раз, чтобы начать игровой цикл, в нашем случае это будет показ меню, катсцена
    public void Begin()
    {
        _duckFactory.CreateDuck(_spawnPoint.position);
    }
}