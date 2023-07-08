using UnityEngine;

namespace Enemy
{
    public class SniperShooter : MonoBehaviour
    {
        [SerializeField] private Bullet _bullet;

        public void Shoot(Vector2 from, Vector2 where)
        {
            Bullet bullet = Instantiate(_bullet, from, Quaternion.identity);
            bullet.Initialize((where - from).normalized);
        }
    }
}