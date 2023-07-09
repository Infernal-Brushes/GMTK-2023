using UnityEngine;

namespace Enemy
{
    public class BombFactory : MonoBehaviour
    {
        [SerializeField] private Bomb _prefab;
        [SerializeField] private HomingIndicator _homingIndicatorPrefab;
        [SerializeField] private Transform[] _bombSpawnPoints;

        public Bomb Create()
        {
            Vector3 bombSpawnPoint = _bombSpawnPoints[Random.Range(0, _bombSpawnPoints.Length)].position;
            Bomb bomb = Instantiate(_prefab, bombSpawnPoint, Quaternion.identity);
            Vector3 indicatorSpawnPoint = bombSpawnPoint - new Vector3(0, 20, 0);
            HomingIndicator homingIndicator = Instantiate(_homingIndicatorPrefab, indicatorSpawnPoint, Quaternion.identity);
            bomb.Initialize(homingIndicator);
            return bomb;
        }
    }
}