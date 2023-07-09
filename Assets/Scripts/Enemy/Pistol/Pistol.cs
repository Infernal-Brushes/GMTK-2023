using System.Collections;
using UnityEngine;

namespace Enemy
{
    public class Pistol : MonoBehaviour
    {
        [SerializeField] private PistolBullet _bulletPrefab;
        [SerializeField] private Aiming _aiming;
        [SerializeField] private float _secondsToMove = 0.3f;
        [SerializeField] private float _speed = 0.5f;

        private Transform _duck;

        public void Initialize(Transform duck)
        {
            _duck = duck;
            StartCoroutine(Move());
        }

        public IEnumerator Shoot()
        {
            _aiming.Setup(new Vector2(0, -25), _duck.transform);
            yield return StartCoroutine(_aiming.PlayAiming());
            PistolBullet bullet = Instantiate(_bulletPrefab, _aiming.CurrentPoint, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
            bullet.Explode();
        }

        private IEnumerator Move()
        {
            float time = 0f;
            bool changedDirection = false;
            
            while (true)
            {
                if (time < _secondsToMove)
                {
                    transform.Translate(Vector3.up * _speed * Time.deltaTime);
                    time += Time.deltaTime;
                }


                if (!changedDirection && time >= _secondsToMove)
                    yield return new WaitForSeconds(Random.Range(2.2f, 3.5f));

                if (time >= _secondsToMove)
                {
                    changedDirection = true;
                    transform.Translate(Vector3.down * _speed * Time.deltaTime);
                    time += Time.deltaTime;
                    
                    if (time >= _secondsToMove * 2)
                    {
                        time = 0;
                        changedDirection = false;
                        yield return null;
                    }
                }
            }
        }
    }
}