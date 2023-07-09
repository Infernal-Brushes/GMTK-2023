using System;
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
        _duckMovement.Initialize(_duckHealth, _inputService);
        _duckView.Initialize(_duckMovement, _duckHealth);
    }

    private void Update()
    {
        if (!_duckHealth.IsAlive && transform.position.y < -40)
            Destroy(gameObject);
    }
}