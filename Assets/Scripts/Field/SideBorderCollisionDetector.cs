using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideBorderCollisionDetector : MonoBehaviour
{
    [SerializeField] private int direction;

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<DuckMovement>(out var duckMovement) && direction != 0)
            duckMovement.ChangeDirection(direction);
    }
}
