using DanPie.Framework.Coroutines;
using DanPie.Framework.Pooling;
using UnityEngine;

namespace DanPie.Framework.AudioManagement
{
    public class AudioSourceControllerProvider : CoroutineExecutor
    {
        [Min(0)]
        [SerializeField] private int _sourcesInitialCount = 5;

        private PoolOfType<AudioSourceController> _audioSourceControllerPool;

        public AudioSourceController GetAudioSourceUser()
        {
            return _audioSourceControllerPool.TakeInstance();
        }

        protected void Awake()
        {
            var poolBehaviour = new PoolObjectInitializingBehaviour<AudioSourceController>()
            {
                OnCreatedAction = (x) => x.AudioSource.enabled = false,
                OnDisposedAction = (x) => Destroy(x.AudioSource)
            };
            _audioSourceControllerPool 
                = new PoolOfType<AudioSourceController>("AudioSourceUsers", NewAudioSourceUser, poolBehaviour);
            _audioSourceControllerPool.SetInstancesCount(_sourcesInitialCount);
        }

        private AudioSourceController NewAudioSourceUser()
        {
            return new AudioSourceController(
                gameObject.AddComponent<AudioSource>(),
                this,
                (x) => _audioSourceControllerPool.ReturnInstance(x));
        }
    }
}
