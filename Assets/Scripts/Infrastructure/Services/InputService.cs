using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputService : MonoBehaviour
{
    public event Action Swing;
    public event Action<float> FlyDirectionChanged;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Swing?.Invoke();
        
        if (Input.GetAxis("Horizontal") != 0)
            FlyDirectionChanged?.Invoke(Input.GetAxis("Horizontal"));
    }
}
