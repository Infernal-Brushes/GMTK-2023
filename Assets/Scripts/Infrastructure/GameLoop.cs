using UnityEngine;

public class GameLoop : MonoBehaviour
{
    [SerializeField] private DuckContainer _duckPrefab;
    [SerializeField] private Transform _spawnPoint;
    
    private InputService _inputService;
    private DuckContainer _duckContainer;

    public void Initialize(InputService inputService)
    {
        _inputService = inputService;
    }

    public void Begin()
    {
        _duckContainer = Instantiate(_duckPrefab, _spawnPoint);
        _duckContainer.Initialize(_inputService);
    }
}