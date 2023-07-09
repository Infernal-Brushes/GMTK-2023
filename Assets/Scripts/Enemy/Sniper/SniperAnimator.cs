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
        
        public void StartWalking()
        {
            _sniperAnimator.SetBool(_isWalking, true);
        }

        public void MountForAim()
        {
            _sniperAnimator.SetBool(_isWalking, false);
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
