using UnityEngine;

namespace Enemy
{
    public class SniperDirectionApplier : MonoBehaviour
    {
        [SerializeField] private Transform _graphicsContainerTransform;

        public void SetDirection(int horizontalDirection)
        {
            var previousScale = _graphicsContainerTransform.localScale;
            previousScale.x = Mathf.Sign(horizontalDirection) * Mathf.Abs(previousScale.x);
            _graphicsContainerTransform.localScale = previousScale;
        }
    }
}
