using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy.Sniper
{
    public class SniperMover : MonoBehaviour
    {
        [SerializeField] private float _movementVelocity;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private SniperDirectionApplier _directionApplier;

        private int _direction = 1;

        public void StartMoving()
        {
            _direction = Random.Range(0, 2) == 1 ? 1 : -1;
            _directionApplier.SetDirection(_direction);
        }

        public void StopMoving() =>
            _direction = 0;

        public void NotifyDirectionChange() =>
            _direction = -_direction;

        private void Update() =>
            _rigidbody.velocity = new Vector2(_direction * _movementVelocity, 0);
    }
}
