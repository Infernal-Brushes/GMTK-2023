using UnityEngine;

public class Trampoline : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<DuckMovement>(out var duckMovement))
            duckMovement.ForceSwing();
    }
}
