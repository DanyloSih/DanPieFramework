using UnityEngine;
using UnityEngine.UI;

namespace DanPie.Framework.WindowSystem.Demo
{
    public class CurrentScoreWindow : WindowObject
    {
        [SerializeField] private Text _scoreText;

        private float _timerValue = 0;

        public void Update()
        {
            _timerValue += Time.deltaTime;
            _scoreText.text = _timerValue.ToString();
        }
    }
}
