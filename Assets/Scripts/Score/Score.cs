using System;
using System.Collections;
using Duck;
using UnityEngine;

namespace Statistics
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private ScoreView _view;
       
        private DuckHealth _duck;

        public int Count { get; private set; }

        public event Action<int> OnCountChanged;
        
        public void Initialize(DuckHealth duck)
        {
            _duck = duck ? duck : throw new ArgumentNullException(nameof(duck));
            Add(2400);
            StartCoroutine(DecreaseCountLoop());
        }

        private IEnumerator DecreaseCountLoop()
        {
            while (_duck.IsAlive)
            {
                yield return new WaitForSeconds(1);
                Decrease(10);
            }
        }

        public void Add(int count)
        {
            Count += count;
            _view.Show(Count);
            OnCountChanged?.Invoke(Count);
        }

        public void Decrease(int count)
        {
            Count = Math.Max(0, Count - count);
            _view.Show(Count);
            OnCountChanged?.Invoke(Count);
        }
    }
}