using UnityEngine;

public class DuckContainer : MonoBehaviour
{
    [SerializeField] private DuckMovement _duckMovement;
    private InputService _inputService;


    public void Initialize(InputService inputService)
    {
        _inputService = inputService;
        _duckMovement.Initialize();
    }
}