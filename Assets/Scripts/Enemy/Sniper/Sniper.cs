using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy.Sniper
{
    public class Sniper : MonoBehaviour
    {
        [SerializeField] private SniperAim _aim;
        [SerializeField] private SniperAnimator _animator;
        [SerializeField] private SniperMover _mover;
        [SerializeField] private SniperShooter _shooter;
        [SerializeField] private Transform _gunTooltipTransform;

        [Space(10), Header("Различные временные промежутки")] 
        [SerializeField] private float _freeRoamTimeMin;
        [SerializeField] private float _freeRoamTimeMax;
        [SerializeField] private float _aimingTimeMin;
        [SerializeField] private float _aimingTimeMax;
        
        [Tooltip("Время, которое должно пройти перед выстрелом после скрытия линии прицела")]
        [SerializeField] private float _aimToShootTimeMin;
        [SerializeField] private float _aimToShootTimeMax;

        private Transform _duck;

        private void Initialize(DuckMovement duck)
        {
            _duck = duck.transform;
            StartCoroutine(Behave());
        }

        private IEnumerator Behave()
        {
            while (true)
            { 
                _mover.StartMoving();
                yield return new WaitForSeconds(Random.Range(_freeRoamTimeMin, _freeRoamTimeMax));
                _mover.StopMoving();
                
                _mover.StopMoving();
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
