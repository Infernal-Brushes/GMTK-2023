using UnityEngine;

namespace Enemy
{
    /// <summary>
    /// Класс содержит методы, изменяющие анимацию снайпера
    /// </summary>
    public class SniperAnimator : MonoBehaviour
    {
        
        // TODO: Создать хэши для полей аниматора

        [SerializeField] private Animator _animator;

        public void StartWalking()
        {
            Debug.Log("The Sniper is walking!");
        }


        public void MountForAim()
        {
            Debug.Log("The sniper has mounted to aim!");
        }

        public void ExpressShoot()
        {
            Debug.Log("The Sniper has made a shot!");
        }

        public void Reload()
        {
            Debug.Log("The Sniper has reloaded!");
        }

    }
}
