using System.Collections;
using UnityEngine;

namespace GMTK2023.Score
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private ScoreView _view;

        private int _count;

        private IEnumerator Start()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                Add(10);
            }
        }

        public void Add(int count)
        {
            _count += count;
            _view.Show(_count);
        }
    }
}
