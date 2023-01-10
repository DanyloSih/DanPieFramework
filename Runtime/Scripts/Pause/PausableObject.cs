using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace DanPie.Framework.Pause
{
    public abstract class PausableObject : MonoBehaviour, IPausable, IPauseStateProvider
    {
        public CancellationTokenSource OnPausedCTS { get; private set; } = new CancellationTokenSource();
        public bool IsPaused { get; private set; } = false;

        public async Task WaitUntil(Func<bool> condition, int frequency = 10, int timeout = -1)
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
                    await WaitUntil(() => IsPaused, frequency);
                    startTime = DateTime.Now;
                    await Task.Delay(remainTime, OnPausedCTS.Token);
                    break;
                }
                catch (TaskCanceledException)
                {
                    remainTime -= (DateTime.Now - startTime).Milliseconds;
                }
            }
            await WaitUntil(() => IsPaused, frequency);
        }

        public void Pause()
        {
            enabled = false;
            IsPaused = true;
            OnPausedCTS.Cancel();
            OnPause();
        }

        public void Resume()
        {
            OnPausedCTS = new CancellationTokenSource();
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
