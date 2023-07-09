using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class Sniper : MonoBehaviour
    {
        [SerializeField] private SniperAim _aim;
        [SerializeField] private SniperAnimator _animator;
        [SerializeField] private SniperMovement Movement;
        [SerializeField] private SniperShooter _shooter;
        [SerializeField] private Transform _gunTooltipTransform;

        [Space(10), Header("Различные временные промежутки")] [SerializeField]
        private float _freeRoamTimeMin;

        [SerializeField] private float _freeRoamTimeMax;
        [SerializeField] private float _aimingTimeMin;
        [SerializeField] private float _aimingTimeMax;

        [Tooltip("Время, которое должно пройти перед выстрелом после скрытия линии прицела")] [SerializeField]
        private float _aimToShootTimeMin;

        [SerializeField] private float _aimToShootTimeMax;

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
                _animator.StartWalking();
                Movement.StartMoving();
                yield return new WaitForSeconds(Random.Range(_freeRoamTimeMin, _freeRoamTimeMax));
                Movement.StopMoving();
                _animator.MountForAim();
             
                _aim.StartTracking(_duck);
                yield return new WaitForSeconds(Random.Range(_aimingTimeMin, _aimingTimeMax));

                _aim.StopTracking();
                yield return new WaitForSeconds(Random.Range(_aimToShootTimeMin, _aimToShootTimeMax));

                _shooter.Shoot(_gunTooltipTransform.position, _duck.position);
                _animator.ExpressShoot();
            }
        }
    }
}