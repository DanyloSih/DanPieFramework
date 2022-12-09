using UnityEngine;

namespace DanPie.Framework.Pause
{
    public class TimeScalePauseController : MonoBehaviour, IPausable
    {
        private float _previousTimeScale = 1f;

        public void Pause()
        {
            _previousTimeScale = Time.timeScale;
            Time.timeScale = 0;
        }

        public void Resume()
        {
            Time.timeScale = _previousTimeScale;   
        }
    }
}
