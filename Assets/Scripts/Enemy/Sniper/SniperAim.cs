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
        }

        private IEnumerator TrackingCoroutine(Transform target)
        {
            while (true)
            {
                _shoulderTransform.LookAt(target, _armDirection);
                _lineRenderer.SetPositions(new []{ _gunTipTransform.position, target.position });
                yield return null;
            }
        }
    }
}
