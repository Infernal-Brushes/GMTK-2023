using TMPro;
using UnityEngine;

namespace Statistics
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        public void Show(int score)
        {
            _text.text = score.ToString();
        }
    }
}
