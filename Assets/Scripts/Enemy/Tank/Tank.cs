using System.Collections;
using UnityEngine;

namespace Enemy
{
    public class Tank : MonoBehaviour
    {
        [SerializeField] private AudioSource _shootSound;
        [SerializeField] private SniperMovement _movement;
        [SerializeField] private SniperShooter _shooter;
        [SerializeField] private Transform _gunTooltipTransform;
        [SerializeField] private GameObject _aimPrefab;
        [SerializeField] private EnemyAnimator _animator;
        
        [Space(10), Header("Различные временные промежутки")] 
        [SerializeField] private float _freeRoamTimeMin;
        [SerializeField] private float _freeRoamTimeMax;
        
        private Transform _duck;

        public void Initialize(Transform duck)
        {
            _duck = duck;
            StartCoroutine(Behave());
        }

        private IEnumerator Behave()
        {
            yield return _animator.PlayFirstMovement();

            while (true)
            {
                _movement.StartMoving();
                yield return new WaitForSeconds(Random.Range(_freeRoamTimeMin, _freeRoamTimeMax));
                _movement.StopMoving();
                yield return new WaitForSeconds(2);
                _shootSound.Play();
                _shooter.Shoot(_gunTooltipTransform.position, _duck.position);
                GameObject aim = Instantiate(_aimPrefab, _duck.position, Quaternion.identity);
                Destroy(aim, 0.2f);
            }
        }
    }
}