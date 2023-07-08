using Enemy.Sniper;
using UnityEngine;

public class SideBorderCollisionDetector : MonoBehaviour
{
    [SerializeField] private int direction;

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<DuckMovement>(out var duckMovement) && direction != 0)
            duckMovement.ChangeDirection(direction);
        // TODO: По хорошему бы сделать, чтобы снайпер сам детектил, когда ему развернуться, да?
        else if (other.gameObject.TryGetComponent<SniperMovement>(out var sniperMover))
            sniperMover.NotifyDirectionChange();
    }
}
