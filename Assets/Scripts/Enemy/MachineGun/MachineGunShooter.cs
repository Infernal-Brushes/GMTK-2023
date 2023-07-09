using System.Collections;
using UnityEngine;

namespace Enemy
{
    public class MachineGunShooter : MonoBehaviour
    {
        [SerializeField] private MachineGunBullet _bulletPrefab;
        [SerializeField] private Transform[] _gunTipTransforms;
        
        [Tooltip("Количество времени между каждым выстрелом в очереди")]
        [SerializeField] private float _timeBetweenShots;

        [Space(10), Header("Количесство выстрелов  в очереди")]
        [SerializeField] private int _shotsInQueueMin;
        [SerializeField] private int _shotsInQueueMax;

        public bool IsShooting { private set; get; }

        public void Shoot() =>
            StartCoroutine(PerformShooting());

        private IEnumerator PerformShooting()
        {
            IsShooting = true;

            var shotsInQueue = Random.Range(_shotsInQueueMin, _shotsInQueueMax + 1);
            for (int i = 0; i < shotsInQueue; i++)
            {
                foreach (var tipTransform in _gunTipTransforms)
                {
                    var bullet = Instantiate(_bulletPrefab.gameObject);
                    bullet.transform.position = tipTransform.position;
                }

                yield return new WaitForSeconds(_timeBetweenShots);
            }

            IsShooting = false;
        }
    }
}
