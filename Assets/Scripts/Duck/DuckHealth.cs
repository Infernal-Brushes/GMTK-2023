using System;
using UnityEngine;

namespace Duck
{
    public class DuckHealth : MonoBehaviour
    {
        public event Action Died;
        
        public bool IsAlive { get; private set; } = true;
       
        public void Die()
        {
            IsAlive = false;
            Died?.Invoke();
        }
    }
}
