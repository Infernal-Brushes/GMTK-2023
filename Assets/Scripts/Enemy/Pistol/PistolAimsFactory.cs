using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GMTK2023.Enemy
{
    public class PistolAimsFactory : MonoBehaviour
    {
        [SerializeField] private PistolAim _aim;
        [SerializeField] private float _createOffset = 1.2f;

        private Transform _duck;

        public void Initialize(Transform duck)
        {
            _duck = duck ? duck : throw new ArgumentNullException(nameof(duck));
        }

        public PistolAim[] CreateGroup()
        {
            PistolAim firstAim = Create();
            PistolAim secondAim = CreateAimNear(firstAim.Position);

            return new PistolAim[]
            {
                firstAim,
                secondAim
            };
        }

        public PistolAim Create()
        {
            return CreateAimNear(_duck.transform.position);
        }

        private PistolAim CreateAimNear(Vector2 position)
        {
            return Instantiate(_aim, position + Random.insideUnitCircle * _createOffset, Quaternion.identity);
        }
    }
}