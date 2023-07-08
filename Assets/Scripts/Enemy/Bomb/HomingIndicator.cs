using UnityEngine;

namespace Enemy.Bomb
{
    public class HomingIndicator : MonoBehaviour
    {
        // Можно добавить анимацию исчезновения индикатора, но пока этот метод только удаляет его со сцены
        public void DestroySelf() =>
            Destroy(gameObject);
    }
}
