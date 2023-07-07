using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputService : MonoBehaviour
{
    public event Action Tapped;

    public void Update()
    {
        if (Input.GetAxis("Fire") != 0)
            Tapped?.Invoke();
    }
}
