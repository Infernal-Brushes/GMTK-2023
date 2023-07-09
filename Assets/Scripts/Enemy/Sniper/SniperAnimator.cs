using UnityEngine;

namespace Enemy
{
    /// <summary>
    /// Класс содержит методы, изменяющие анимацию снайпера
    /// </summary>
    public class SniperAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
     
        private readonly int _isWalking = Animator.StringToHash("IsWalking");

        public void StartWalking()
        {
            _animator.SetBool(_isWalking, true);
        }


        public void MountForAim()
        {
            _animator.SetBool(_isWalking, false);
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
