﻿using UnityEngine;

namespace Enemy.Sniper
{
    public class SniperShooter : MonoBehaviour
    {

        [SerializeField] private SniperBullet _bullet;

        public void Shoot(Vector2 from, Vector2 where)
        {
            var bullet = Instantiate(_bullet.gameObject);
            bullet.transform.position = from;
            bullet.GetComponent<SniperBullet>().Initialize(from - where);
        }
    }
}