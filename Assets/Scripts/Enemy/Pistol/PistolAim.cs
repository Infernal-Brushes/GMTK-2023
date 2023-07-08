using UnityEngine;

namespace GMTK2023.Enemy
{
    public class PistolAim : MonoBehaviour
    {
        public Vector2 Position => transform.position;

        public void DestroySelf()
        {
            Destroy(gameObject);
        }
    }
}
