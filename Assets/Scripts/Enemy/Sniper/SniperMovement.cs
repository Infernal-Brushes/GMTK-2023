using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class SniperMovement : MonoBehaviour
    {
        [SerializeField] private float _movementVelocity;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private SniperDirectionApplier _directionApplier;

        private int _direction = 1;

        public void StartMoving()
        {
            _direction = Random.Range(0, 2) == 1 ? 1 : -1;
            _directionApplier.SetDirection(_direction);
            Debug.Log("Start moving! " + _direction);
        }

        public void StopMoving()
        {
            Debug.Log("Stopped moving!");
            _direction = 0;
        }

        public void NotifyDirectionChange()
        {
            _direction = -_direction;
            _directionApplier.SetDirection(_direction);
        }

        private void Update()
        {
            _rigidbody.velocity = Vector2.right * (_direction * _movementVelocity);
        }
    }
}

