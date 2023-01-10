using UnityEngine;

namespace DanPie.Framework.Pause
{
    public class PausableWaitForSeconds : CustomYieldInstruction
    {
        private float _waitTime;
        private float _timer;
        private IPauseStateProvider _pauseStateProvider;

        public PausableWaitForSeconds(float waitTime, IPauseStateProvider pauseStateProvider)
        {
            _waitTime = waitTime;
            _timer = _waitTime;
            _pauseStateProvider = pauseStateProvider;
        }

        public override bool keepWaiting 
        {
            get
            {
                if (_timer <= 0)
                {
                    return false;
                }
                else
                {
                    if (!_pauseStateProvider.IsPaused)
                    {
                        _timer -= Time.deltaTime;
                    }
                    return true;
                }
            }
        }
    }
}
