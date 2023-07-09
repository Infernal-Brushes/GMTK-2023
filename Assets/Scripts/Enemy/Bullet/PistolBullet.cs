using Duck;
using UnityEngine;

namespace Enemy
{
    public class PistolBullet : MonoBehaviour
    {
        [SerializeField] private float _radius = 1.2f;

        private readonly Collider2D[] _colliders = new Collider2D[30];

        public void Explode()
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
