using System;
using DanPie.Framework.Coroutines;
using DanPie.Framework.Pooling;
using UnityEngine;

namespace DanPie.Framework.AudioManagement
{
    public class AudioSourceController : IPoolable
    {
        private readonly ICoroutineExecutor _coroutineExecutor;
        private readonly Action<AudioSourceController> _returnToPoolAction;
        private Coroutine _playProcess;
        private bool _returnToPoolAfterPlay;

        public AudioSourceController(
            AudioSource audioSource,
            ICoroutineExecutor coroutineExecutor,
            Action<AudioSourceController> returnToPoolAction)
        {
            AudioSource = audioSource;
            _coroutineExecutor = coroutineExecutor;
            _returnToPoolAction = returnToPoolAction;
        }

        public string PoolName { get; private set; }
        public AudioSource AudioSource { get; private set; }
        public AudioClipData PlayingAudioClipData { get; private set; }
        public bool IsBusy { get => AudioSource.enabled; }

        public void InitPoolableObject(string poolName)
        {
            PoolName = poolName;
        }

        public void Play(AudioClipData clipData, bool isLoop = false, bool returnToPoolAfterPlay = true)
        {
            if (IsBusy)
            {
                throw new AudioSourceBusyException();
            }

            _returnToPoolAfterPlay = returnToPoolAfterPlay;
            AudioSource.enabled = true;
            PlayingAudioClipData = clipData;
            AudioSource.loop = isLoop;
            AudioSource.outputAudioMixerGroup = clipData.MixerGroup;
            AudioSource.clip = clipData.AudioClip;
            float clipDuration = clipData.AudioClip.length;
            AudioSource.Play();
            if (!isLoop)
            {
                _playProcess = _coroutineExecutor.ExecuteCoroutine(CoroutineUtilities.WaitForSeconds(clipDuration, Stop));
            }
        }

        public void Stop()
        {
            if (!IsBusy)
            {
                return;
            }

            if (_playProcess != null)
            {
                _coroutineExecutor.BreakCoroutine(_playProcess);
                _playProcess = null;
            }

            PlayingAudioClipData = null;
            ResetAudioSource();
            AudioSource.enabled = false;

            if (_returnToPoolAfterPlay)
            {
                _returnToPoolAction.Invoke(this);
            }
        }

        private void ResetAudioSource()
        {
            AudioSource.Stop();
            AudioSource.playOnAwake = false;
            AudioSource.loop = false;
            AudioSource.clip = null;
        }
    }
}
