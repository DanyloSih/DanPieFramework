using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace DanPie.Framework.Pause
{

    public abstract class PausableObject : MonoBehaviour, IPausable
    {
        private List<Task> _pausableDelayTasks = new List<Task>();
        private CancellationTokenSource _onPausedCTS = new CancellationTokenSource();

        public CancellationToken OnPauseCancellationToken { get; private set; } = new CancellationToken();
        public bool IsPaused { get; private set; } = false;
        
        public async Task Until(Func<bool> condition, int frequency = 10, int timeout = -1)
        {
            var waitTask = Task.Run(async () =>
            {
                while (condition()) await Task.Delay(frequency);
            });

            if (waitTask != await Task.WhenAny(waitTask, Task.Delay(timeout)))
                throw new TimeoutException();
        }

        public async Task PausableDelay(int delay, int frequency = 10)
        {
            int remainTime = delay;
            DateTime startTime = new DateTime();

            while (remainTime > 0)
            {
                try
                {
                    await Until(() => IsPaused, frequency);
                    startTime = DateTime.Now;
                    await Task.Delay(remainTime, _onPausedCTS.Token);
                    break;
                }
                catch (TaskCanceledException)
                {
                    remainTime -= (DateTime.Now - startTime).Milliseconds;
                } 
            }
            await Until(() => IsPaused, frequency);
        }

        public void Pause()
        {
            enabled = false;
            IsPaused = true;
            _onPausedCTS.Cancel();
            OnPause();
        }

        public void Resume()
        {
            _onPausedCTS = new CancellationTokenSource();
            enabled = true;
            IsPaused = false;
            OnResume();
        }

        protected void Start()
        {
            Pause();
            Resume();
            OnStart();
        }

        protected virtual void OnPause() { }

        protected virtual void OnResume() { }

        protected virtual void OnStart() { }
    }
}
