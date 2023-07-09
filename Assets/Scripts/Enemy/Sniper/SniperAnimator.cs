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
        private readonly int _isAiming = Animator.StringToHash("ISAiming");
        private readonly int _shoot = Animator.StringToHash("Shoot");

        public void StartWalking()
        {
            _animator.SetBool(_isAiming, false);
            _animator.SetBool(_isWalking, true);
        }


        public void MountForAim()
        {
            _animator.SetBool(_isWalking, false);
            _animator.SetBool(_isAiming, true);
        }

        public void ExpressShoot()
        {
            _animator.SetTrigger(_shoot);
        }

    }
}
