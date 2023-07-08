using GMTK2023.Duck;
using UnityEngine;

namespace GMTK2023.Enemy
{
    public class PistolBullet : MonoBehaviour
    {
        [SerializeField] private float _radius = 1.2f;

        private readonly Collider2D[] _colliders = new Collider2D[30];

        public void Throw()
        {
            int results = Physics2D.OverlapCircleNonAlloc(transform.position, _radius, _colliders);

            for (int i = 0; i < results; i++)
            {
                if (_colliders[i].TryGetComponent(out DuckHealth duck))
                    duck.Die();
            }
        }
    }
}
