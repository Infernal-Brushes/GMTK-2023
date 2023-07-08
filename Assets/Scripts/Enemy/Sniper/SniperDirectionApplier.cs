using UnityEngine;

namespace Enemy.Sniper
{
    public class SniperDirectionApplier : MonoBehaviour
    {
        [SerializeField] private Transform _graphicsContainerTransform;

        public void SetDirection(int direction)
        {
            var previousScale = _graphicsContainerTransform.localScale;
            previousScale.x = Mathf.Sign(direction) * Mathf.Abs(previousScale.x);
        }
    }
}
