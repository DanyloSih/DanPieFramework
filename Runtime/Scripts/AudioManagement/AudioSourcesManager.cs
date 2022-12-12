using System;
using System.Collections.Generic;
using System.Linq;
using DanPie.Framework.Coroutines;
using DanPie.Framework.Pooling;
using UnityEngine;
using UnityEngine.Audio;

namespace DanPie.Framework.AudioManagement
{
    public class AudioSourcesManager
    {
        private int _sourcesInitialCount = 5;
        private readonly GameObject _sourcesContainer;
        private readonly CoroutineExecutor _coroutineExecutor;
        private PoolOfType<AudioSourceController> _audioSourceControllerPool;
        private List<AudioSourceController> _activeSources = new List<AudioSourceController>();

        public List<AudioSourceController> GetActiveSourceControllersBy(AudioMixerGroup audioMixerGroup)
        {
            return _activeSources.Where((x) => x.PlayingAudioClipData.MixerGroup == audioMixerGroup).ToList();
        }

        public AudioSourcesManager(
            int sourcesInitialCount,
            GameObject sourcesContainer,
            CoroutineExecutor coroutineExecutor)
        {
            if (sourcesInitialCount < 0)
            {
                throw new ArgumentException($"The {nameof(sourcesInitialCount)} can't be less then zero!");
            }

            _sourcesInitialCount = sourcesInitialCount;
            _sourcesContainer = sourcesContainer;
            _coroutineExecutor = coroutineExecutor;

            var poolBehaviour = new PoolObjectInitializingBehaviour<AudioSourceController>()
            {
                OnCreatedAction = (x) => x.AudioSource.enabled = false,
                OnDisposedAction = (x) => MonoBehaviour.Destroy(x.AudioSource),
                OnReturnedToPoolAction = (x) => _activeSources.Remove(x)
            };

            _audioSourceControllerPool 
                = new PoolOfType<AudioSourceController>("AudioSourceUsers", NewAudioSourceUser, poolBehaviour);

            _audioSourceControllerPool.SetInstancesCount(_sourcesInitialCount);
        }

        public AudioSourceController GetAudioSourceController()
        {
            var instance = _audioSourceControllerPool.TakeInstance();
            _activeSources.Add(instance);
            return instance;
        }

        private AudioSourceController NewAudioSourceUser()
        {
            return new AudioSourceController(
                _sourcesContainer.AddComponent<AudioSource>(),
                _coroutineExecutor,
                (x) => _audioSourceControllerPool.ReturnInstance(x));
        }
    }
}
