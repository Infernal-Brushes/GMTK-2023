using System.Collections;
using UnityEngine;

namespace Enemy
{
    public class EnemyAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        public IEnumerator PlayFirstMovement()
        {
            _animator.Play("FirstMovement");
            yield return new WaitForSeconds(_animator.GetCurrentAnimatorClipInfo(0).Length);
        }
    }
}