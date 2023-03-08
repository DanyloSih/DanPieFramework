using System.Collections;
using DanPie.Framework.Pause;
using UnityEngine;

namespace DanPie.Framework.Effects
{
    public class DestroyTimer : PausableObject
    {
        [SerializeField] private float _destroyTime;
        [SerializeField] private bool _startTimerOnEnable = true;

        private Coroutine _timerCoroutine;

        public void OnEnable()
        {
            if (_startTimerOnEnable)
            {
                StartTimer();
            }
        }

        public void StartTimer()
        {
            if (_timerCoroutine != null)
            {
                _timerCoroutine = StartCoroutine(TimerProcess());
            }
        }

        private IEnumerator TimerProcess()
        {
            yield return new PausableWaitForSeconds(_destroyTime, this);
        }
    }
}
