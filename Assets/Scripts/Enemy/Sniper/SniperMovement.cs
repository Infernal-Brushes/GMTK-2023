using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class SniperMovement : MonoBehaviour
    {
        [SerializeField] private float _movementVelocity;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private SniperDirectionApplier _directionApplier;

        private bool _startedMoving;
        private int _direction = 1;

        public void StartMoving()
        {
            _startedMoving = true;
            _direction = Random.Range(0, 2) == 1 ? 1 : -1;
            _directionApplier.SetDirection(_direction);
        }

        public void StopMoving() =>
            _direction = 0;

        public void NotifyDirectionChange() =>
            _direction = -_direction;

        private void Update()
        {
            if (!_startedMoving)
                return;

            _rigidbody.MovePosition(_rigidbody.position + new Vector2(_direction, 0) * _movementVelocity * Time.deltaTime);
        }
    }
}
