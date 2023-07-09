using System.Collections;
using Enemy;
using UnityEngine;

namespace GMTK2023.Enemy
{
    public class Pistol : MonoBehaviour
    {
        [SerializeField] private PistolBullet _bulletPrefab;
        [SerializeField] private Aiming _aiming;
    
        private Transform _duck;

        public void Initialize(Transform duck)
        {
            _duck = duck;
        }
        
        public IEnumerator Shoot()
        {
            _aiming.Setup(new Vector2(0, -25), _duck.transform);
            yield return StartCoroutine(_aiming.PlayAiming());
            PistolBullet bullet = Instantiate(_bulletPrefab, _aiming.CurrentPoint, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            bullet.Explode();
        }
    }
}