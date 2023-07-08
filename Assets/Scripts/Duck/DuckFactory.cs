using Unity.Mathematics;
using UnityEngine;

namespace Duck
{
    public class DuckFactory : MonoBehaviour
    {
        [SerializeField] private DuckContainer _duckPrefab;
        private InputService _inputService;


        public void Initialize(InputService inputService)
        {
            _inputService = inputService;
        }
        
        public DuckContainer CreateDuck(Vector3 at)
        {
            var duck = Instantiate(_duckPrefab, at, quaternion.identity);
            duck.Initialize(_inputService);
            return duck;
        }
    }
}
