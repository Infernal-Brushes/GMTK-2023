using System;
using UnityEngine;

namespace GMTK2023.Duck
{
    public class DuckHealth : MonoBehaviour
    {
        public Action Died;
        public bool IsAlive { get; private set; } = true;
       
        public void Die()
        {
            IsAlive = false;
            Died?.Invoke();
        }
    }
}