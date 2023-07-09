using Duck;
using Enemy;
using UnityEngine;

public class DuckContainer : MonoBehaviour
{
    public DuckMovement Movement => _duckMovement;
    public DuckHealth Health => _duckHealth;
    
    [SerializeField] private DuckMovement _duckMovement;
    [SerializeField] private DuckHealth _duckHealth;
    [SerializeField] private DuckView _duckView;

    private InputService _inputService;
    
    public void Initialize(InputService inputService)
    {
        _inputService = inputService;
        _duckMovement.Initialize(_inputService);
        _duckView.Initialize(_duckMovement);
    }
}