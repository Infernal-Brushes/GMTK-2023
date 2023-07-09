using System.Collections;
using UnityEngine;

namespace Enemy
{
    /// <summary>
    /// Этот класс отвечает за визуализацию прицеливания.
    /// Он вращает руки снайпера, и рисует тракекторию пули.
    /// </summary>
    public class SniperAim : MonoBehaviour
    {
        [SerializeField] private Transform _shoulderTransform;
        [SerializeField] private LineRenderer _lineRenderer;
        [SerializeField] private Transform _gunTipTransform;
        [SerializeField] private SniperDirectionApplier _directionApplier;

        [Tooltip("Первоначальное направление руки снайпера")]
        [SerializeField] private Vector2 _armDirection;

        private Coroutine _trackingCoroutine;

        public void StartTracking(Transform target)
        {
            _lineRenderer.enabled = true;
            _trackingCoroutine = StartCoroutine(TrackingCoroutine(target));
        }

        public void StopTracking()
        {
            if (_trackingCoroutine != null)
                StopCoroutine(_trackingCoroutine);

            _trackingCoroutine = null;
            _lineRenderer.enabled = false;
            _shoulderTransform.eulerAngles = Vector3.zero;
        }

        private IEnumerator TrackingCoroutine(Transform target)
        {
            while (true)
            {
               _shoulderTransform.LookAt(target, _armDirection);
                
                if (target.position.x > transform.position.x)
                    _shoulderTransform.rotation = Quaternion.Euler(0, 0, -_shoulderTransform.eulerAngles.x);
                else
                    _shoulderTransform.rotation = Quaternion.Euler(0, 0, _shoulderTransform.eulerAngles.x);
                
                _directionApplier.SetDirection(-(int)Mathf.Sign(transform.position.x - target.position.x));

                _lineRenderer.SetPositions(new []{ _gunTipTransform.position, target.position });
                yield return null;
            }
        }
    }
}
