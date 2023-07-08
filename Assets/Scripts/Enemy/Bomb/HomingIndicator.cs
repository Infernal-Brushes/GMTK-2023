using UnityEngine;

namespace Enemy.Bomb
{
    public class HomingIndicator : MonoBehaviour
    {
        /// <summary>
        /// Этот метод вызывается событием аниматора.
        /// </summary>
        private void DestroySelf() =>
            Destroy(gameObject);
    }
}
