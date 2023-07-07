using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GMTK2023.Enemy
{
    public class Pistol : MonoBehaviour
    {
        [SerializeField] private float _shootTime = 2f;
        [SerializeField] private PistolAimsFactory _aimsFactory;
        [SerializeField] private PistolBullet _bulletPrefab;
        
        private void Start()
        {
            StartCoroutine(Shoot());
        }

        private IEnumerator Shoot()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.2f);
                PistolAim[] aims = Random.Range(0, 2) == 0 ? new[] { _aimsFactory.Create() } : _aimsFactory.CreateGroup();

                yield return new WaitForSeconds(_shootTime);

                foreach (PistolAim aim in aims)
                {
                    PistolBullet bullet = Instantiate(_bulletPrefab, aim.Position, Quaternion.identity);
                    aim.DestroySelf();
                    yield return new WaitForSeconds(0.1f);
                    bullet.Throw();
                }
            }
        }
    }
}