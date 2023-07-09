using Duck;
using UnityEngine;

namespace Enemy
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private bool _isMoving;
        private Vector2 _direction;

        public void Initialize(Vector2 direction)
        {
            _direction = direction;
            _isMoving = true;
            Destroy(gameObject, 5);
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.TryGetComponent(out DuckHealth duck))
            {
                duck.Die();
                Destroy(gameObject);
            }
        }

        private void Update()
        {
            if(!_isMoving)
                return;
            
            transform.Translate(_direction * _speed * Time.deltaTime);
        }
    }
}