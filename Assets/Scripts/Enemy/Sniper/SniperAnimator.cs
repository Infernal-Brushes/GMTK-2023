using UnityEngine;

namespace Enemy
{
    /// <summary>
    /// Класс содержит методы, изменяющие анимацию снайпера
    /// </summary>
    public class SniperAnimator : EnemyAnimator
    {
        [SerializeField] private Animator _sniperAnimator;

        private readonly int _isWalking = Animator.StringToHash("IsWalking");
        private readonly int _isAiming = Animator.StringToHash("ISAiming");
        private readonly int _shoot = Animator.StringToHash("Shoot");

        public void StartWalking()
        {
            _sniperAnimator.SetBool(_isAiming, false);
            _sniperAnimator.SetBool(_isWalking, true);
        }


        public void MountForAim()
        {
            _sniperAnimator.SetBool(_isWalking, false);
            _sniperAnimator.SetBool(_isAiming, true);
        }

        public void ExpressShoot()
        {
            _sniperAnimator.SetTrigger(_shoot);
        }
    }
}