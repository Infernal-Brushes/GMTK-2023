﻿using System.Collections;
using UnityEngine;

namespace Enemy
{
    public class MachineGun : MonoBehaviour
    {
        [SerializeField] private MachineGunRoamer _roamer;
        [SerializeField] private MachineGunShooter _shooter;
        [SerializeField] private EnemyAnimator _animator;
        
        [Space(10), Tooltip("Время, на протяжении которого пушка свободно передвигается")]
        [SerializeField] private float _roamingTimeMin;
        [SerializeField] private float _roamingTimeMax;

        [Space(10), Header("Сколько очередей зенитка выстреливает за раз")]
        [SerializeField] private int _queuesInRowMin;

        [SerializeField] private int _queuesInRowMax;

        public void Initialize(Transform duck, Rect screenDimensionsInWorldUnits)
        {
            _roamer.Initialize(duck, screenDimensionsInWorldUnits);
            StartCoroutine(Behave());
        }

        private IEnumerator Behave()
        {
            yield return StartCoroutine(_animator.PlayFirstMovement());
            
            while (true)
            {
                _roamer.StartRoaming();
                yield return new WaitForSeconds(Random.Range(_roamingTimeMin, _roamingTimeMax));
                _roamer.StopRoaming();

                var queuesCount = Random.Range(_queuesInRowMin, _queuesInRowMax);
                for (int i = 0; i < queuesCount; i++)
                {
                    _shooter.Shoot();
                    yield return new WaitUntil(() => !_shooter.IsShooting);
                }
            }
        }
    }
}
