using GMTK2023.Duck;
using GMTK2023.Enemy;
using UnityEngine;

public class DuckContainer : MonoBehaviour
{
    [SerializeField] private DuckMovement _duckMovement;
    [SerializeField] private DuckHealth _duckHealth;
    [SerializeField] private PistolAimsFactory _pistolAimsFactory;

    private InputService _inputService;
    
    public void Initialize(InputService inputService)
    {
        _inputService = inputService;
        _duckMovement.Initialize(_inputService);
        //_pistolAimsFactory.Initialize(_duckMovement);
    }
}