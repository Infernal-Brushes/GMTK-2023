using UnityEngine;

namespace Enemy
{
    public class BombLauncher : MonoBehaviour
    {
        [SerializeField] private Bomb _bombPrefab;
        [SerializeField] private HomingIndicator _homingIndicatorPrefab;
        [SerializeField] private float _homingIndicatorOffsetY;

        [Space(10), Header("Горизонтальное отклонение от позиции игрока при спавне бомбы")]
        [SerializeField] private float _horizontalOffsetMin;
        [SerializeField] private float _HorizontalOffsetMax;

        /// <summary>
        /// Инициализирует лаунчер снаряда.
        /// </summary>
        /// <param name="duck">Transform утки-игрока</param>
        /// <param name="screenDimensionsInWorldUnits">
        /// Измерения игрового поля с его координатами.
        /// Этот параметр используется для получения крайних точек экрана.
        /// </param>
        public void Initialize(Transform duck, Rect screenDimensionsInWorldUnits)
        {
            var horizontalOffset = Random.Range(_horizontalOffsetMin, _HorizontalOffsetMax);
            var bombX = duck.position.x + Random.Range(-1, 2) * horizontalOffset;
            bombX = Mathf.Clamp(bombX, screenDimensionsInWorldUnits.xMin, screenDimensionsInWorldUnits.xMax);

            var indicator = Instantiate(_homingIndicatorPrefab.gameObject);
            var indicatorY = screenDimensionsInWorldUnits.yMin + _homingIndicatorOffsetY;
            indicator.transform.position = new Vector2(bombX, indicatorY);
            
            var bomb = Instantiate(_bombPrefab.gameObject);
            bomb.transform.position = new Vector2(bombX, screenDimensionsInWorldUnits.yMax);
            bomb.GetComponent<Bomb>().Initialize(indicator.GetComponent<HomingIndicator>());
        }
        
    }
}
