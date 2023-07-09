using Duck;
using UnityEngine;

namespace Enemy
{
    public class SniperBullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _velocity;

        public void Initialize(Vector2 direction) =>
            _rigidbody.velocity = direction.normalized * _velocity;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out DuckHealth duck))
                duck.Die();
        }
    }
}