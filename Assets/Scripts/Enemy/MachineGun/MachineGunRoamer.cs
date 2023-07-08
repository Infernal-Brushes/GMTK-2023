using System.Collections;
using UnityEngine;

namespace Enemy.MachineGun
{
    public class MachineGunRoamer : MonoBehaviour
    {

        [SerializeField] private float _movementVelocity;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _maxDistanceFromPlayer;

        private Rect _screenDimensions;
        private Transform _duck;
        private Coroutine _roamingCoroutine;
        private int _direction = 1;

        public void Initialize(DuckMovement duck, Rect screenDimensionsInWorldUnits)
        {
            _screenDimensions = screenDimensionsInWorldUnits;
            _duck = duck.transform;
        }

        public void StartRoaming()
        {
            if (_roamingCoroutine != null)
                StopCoroutine(_roamingCoroutine);

            _roamingCoroutine = StartCoroutine(Roam());
        }

        public void StopRoaming()
        {
            if (_roamingCoroutine != null)
                StopCoroutine(_roamingCoroutine);
            
            _roamingCoroutine = null;
            _rigidbody.velocity = Vector2.zero;
        }
        
        private IEnumerator Roam()
        {
            while (true)
            {
                _rigidbody.velocity = new Vector2(_direction * _movementVelocity, 0);

                if (_direction > 0)
                {
                    yield return new WaitUntil(() => transform.position.x > Mathf.Min(
                        _duck.position.x + _maxDistanceFromPlayer,
                        _screenDimensions.xMax
                    ));
                }
                else
                {
                    yield return new WaitUntil(() => transform.position.x < Mathf.Max(
                        _duck.position.x + _maxDistanceFromPlayer,
                        _screenDimensions.xMin
                    ));
                }

                _direction = -_direction;
            }
        }
    }
}
