using Duck;
using UnityEngine;

public class DuckView : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void Initialize(DuckMovement duckMovement, DuckHealth duckHealth)
    {
        duckMovement.OnSwing += Swing;
        duckMovement.DirectionChanged += ChangeDirection;
        duckHealth.Died += Dead;
    }

    private void Swing()
    {
        _animator.SetTrigger("Swing");
    }

    private void Dead()
    {
        _animator.SetTrigger("Dead");
        _animator.SetInteger("RandomDeadPose", Random.Range(1, 4));
    }

    private void ChangeDirection(int direction)
    {
        transform.localScale = new Vector3(direction, 1, 1);
    }
}