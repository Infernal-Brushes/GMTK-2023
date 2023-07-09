using UnityEngine;

public class DuckView : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void Initialize(DuckMovement duckMovement)
    {
        duckMovement.OnSwing += Swing;
    }

    private void Swing()
    {
        _animator.SetTrigger("Swing");
    }
}