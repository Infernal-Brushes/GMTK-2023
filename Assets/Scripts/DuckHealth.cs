using UnityEngine;

namespace GMTK2023.Duck
{
    public class DuckHealth : MonoBehaviour
    {
        [SerializeField] private GameObject _losePanel;

        public bool IsAlive { get; private set; } = true;
       
        public void Die()
        {
            _losePanel.SetActive(true);
            Time.timeScale = 0f;
            IsAlive = false;
        }
    }
}