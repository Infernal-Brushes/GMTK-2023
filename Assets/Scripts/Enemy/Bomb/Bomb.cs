﻿using System.Collections;
using Duck;
using UnityEngine;

namespace Enemy
{
    public class Bomb : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private BombExploder _exploder;
        [SerializeField] private float _descendingVelocity;

        [Tooltip("Время до начала спуска снаряда")] [SerializeField]
        private float _descentStartDelay;

        private HomingIndicator _indicator;

        public void Initialize(HomingIndicator indicator)
        {
            _indicator = indicator;
            StartCoroutine(Descend());
        }

        private IEnumerator Descend()
        {
            yield return new WaitForSeconds(_descentStartDelay);
            _rigidbody.velocity = Vector2.down * Mathf.Abs(_descendingVelocity);
            _indicator.DestroySelf();

            yield return new WaitUntil(() => !_spriteRenderer.isVisible);
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.TryGetComponent(out DuckHealth duckHealth))
            {
                duckHealth.Die();
                GetComponent<Collider2D>().enabled = false;
                _exploder.Explode();
            }
        }
    }
}