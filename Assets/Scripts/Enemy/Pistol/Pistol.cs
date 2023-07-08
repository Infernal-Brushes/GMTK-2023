using System.Collections;
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
            _aiming.Setup(new Vector2(0, -30), _duck.position);
            yield return StartCoroutine(_aiming.PlayAiming());
            PistolBullet bullet = Instantiate(_bulletPrefab, _duck.position, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            bullet.Throw();
        }
    }
}