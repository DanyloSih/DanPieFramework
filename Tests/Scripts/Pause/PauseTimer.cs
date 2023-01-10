using System.Collections;
using UnityEngine;

namespace DanPie.Framework.Pause.Test
{
    public class PauseTimer : MonoBehaviour, IPauseStateProvider
    {
        [SerializeField] private float _time = 2;
        [SerializeField] private bool _invertPauseState = true;

        private bool _state = false;

        public void StartTimer()
        {
            StartCoroutine(FakePause());
        }

        private IEnumerator FakePause()
        {
            _state = _invertPauseState;
            yield return new WaitForSeconds(_time);
            _state = !_invertPauseState;
        }

        public bool IsPaused { get => _state; }
    }
}
