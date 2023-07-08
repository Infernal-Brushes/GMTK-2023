using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GMTK2023.Enemy
{
    public class Aiming : MonoBehaviour
    {
        public event Action Pointed;

        public Vector3 CurrentPoint => _currentPosition;
        
        [SerializeField] private GameObject _aimPoint;
        [Header("Parameters")]
        [SerializeField] private float _duration;
        [SerializeField] private float _offsetLevel;
        [SerializeField] private float _jitterForce;
        [SerializeField] private float _movementSensitivity;
        [SerializeField] private float _destinationThreshold;
        [Header("Points for testing")]
        [SerializeField] private Transform _startPointTransform;
        [SerializeField] private Transform _destinationPointTransform;

        private Vector3 _startPoint;
        private Vector3 _subPoint1;
        private Vector3 _subPoint2;
        private Transform _target;
       // private Vector3 _destinationPoint;

        private Vector3 _currentPosition;

        public void Setup()
        {
            //Setup(_startPointTransform.position, _destinationPointTransform.position);
        }

        public void Setup(Vector2 startPoint, Vector2 destinationPoint)
        {
            _aimPoint.SetActive(false);
            var halfVector = ((destinationPoint - startPoint) / 2);
            var center = halfVector + startPoint;
            _startPoint = startPoint;
            
            var randomPoint = center + Random.insideUnitCircle * halfVector.magnitude * _offsetLevel;
            _subPoint1 = Vector2.Lerp(randomPoint, startPoint, Random.Range(0.1f, 0.9f));
            _subPoint2 = Vector2.Lerp(randomPoint, destinationPoint, Random.Range(0.1f, 0.9f));
            
            //_destinationPoint = destinationPoint;
            //StartCoroutine(PlayAiming());
        }

        public void Setup(Vector2 startPoint, Transform target)
        {
            _aimPoint.SetActive(false);
            var halfVector = (((Vector2)target.position - startPoint) / 2);
            var center = halfVector + startPoint;
            _startPoint = startPoint;
            
            var randomPoint = center + Random.insideUnitCircle * halfVector.magnitude * _offsetLevel;
            _subPoint1 = Vector2.Lerp(randomPoint, startPoint, Random.Range(0.1f, 0.9f));
            _subPoint2 = Vector2.Lerp(randomPoint, target.position, Random.Range(0.1f, 0.9f));
            
            _target = target;
        }

        public IEnumerator PlayAiming()
        {
            _aimPoint.SetActive(true);
            _aimPoint.transform.position = _startPoint;
            _currentPosition = _startPoint;
            float timer = 0;
        
            while (timer < _duration)
            {
                var t = timer / _duration;
                var nextPosition = GetAimPointPosition(t);
                _currentPosition = Vector2.Lerp(_currentPosition, nextPosition, _movementSensitivity);
                _aimPoint.transform.position = _currentPosition;
                yield return new WaitForEndOfFrame();
                timer += Time.deltaTime;
            }

            var destinationPoint = GetAimPointPosition(1);
            while (Vector2.Distance(_currentPosition, destinationPoint) < - _destinationThreshold)
            {
                _currentPosition = Vector2.Lerp(_currentPosition, destinationPoint, _movementSensitivity);
                _aimPoint.transform.position = _currentPosition;
                yield return new WaitForEndOfFrame();
            }
            
            _aimPoint.SetActive(false);
            Pointed?.Invoke();
        }

        private Vector2 GetAimPointPosition(float t)
        {
            var certainPoint = Bezier.GetPoint(_startPoint, _subPoint1, _subPoint2, _target.position, t);
            var pointWithNoise = certainPoint + Random.insideUnitCircle * _jitterForce;
            return pointWithNoise;
        }
    }
}
