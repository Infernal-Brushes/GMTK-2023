using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GMTK2023.Enemy
{
    public class PistolAimsFactory : MonoBehaviour
    {
        [SerializeField] private PistolAim _aim;
        [SerializeField] private float _createOffset = 1.2f;

        public PistolAim[] CreateGroup(Transform duck)
        {
            PistolAim firstAim = Create(duck);
            PistolAim secondAim = CreateAimNear(firstAim.Position);

            return new PistolAim[]
            {
                firstAim,
                secondAim
            };
        }

        public PistolAim Create(Transform duck)
        {
            return CreateAimNear(duck.position);
        }

        private PistolAim CreateAimNear(Vector2 position)
        {
            var aimPosition = position + Random.insideUnitCircle * _createOffset;
            return Instantiate(_aim, aimPosition, Quaternion.identity);
        }
    }
}