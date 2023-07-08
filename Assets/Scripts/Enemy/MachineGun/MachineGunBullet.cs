using System;
using System.Collections;
using GMTK2023.Duck;
using UnityEngine;

namespace Enemy.MachineGun
{
    public class MachineGunBullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private float _verticalVelocity;
        [SerializeField] private float _damage;

        private void Start()
        {
            _rigidbody.velocity = Vector2.up * Mathf.Abs(_verticalVelocity);
            StartCoroutine(WaitUntilFlownAway());
        }

        private IEnumerator WaitUntilFlownAway()
        {
            yield return new WaitUntil(() => !_spriteRenderer.isVisible);
            Destroy(gameObject);
        }

        private IEnumerator BlowUp()
        {
            _particleSystem.Play();
            yield return new WaitUntil(() => !_particleSystem.isPlaying);
            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player"))
                return;
            
            // TODO: Apply damage
            // other.GetComponent<DuckHealth>().ApplyDamage(_damage);

            GetComponent<Collider2D>().enabled = false;
            StartCoroutine(BlowUp());
        }
    }
}
