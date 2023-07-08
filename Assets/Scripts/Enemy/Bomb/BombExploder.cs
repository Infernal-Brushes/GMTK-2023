using System.Collections;
using UnityEngine;

namespace Enemy
{
    public class BombExploder : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;

        public void Explode() =>
            StartCoroutine(ExplosionBehaviour());

        private IEnumerator ExplosionBehaviour()
        {
            _particleSystem.Play();
            yield return new WaitUntil(() => !_particleSystem.isPlaying);
            Destroy(gameObject);
        }
    }
}
