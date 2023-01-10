using System.Collections.Generic;

namespace DanPie.Framework.Pause
{
    public class PauseController : IPauseController, IPauseStateProvider
    {
        private List<IPausableObjectsProvider> _objectsProviders;
        private bool _isPaused = false;

        public PauseController(List<IPausableObjectsProvider> objectsProvider)
        {
            _objectsProviders = objectsProvider;
        }

        public bool IsPaused { get => _isPaused; }

        public void PauseObjects()
        {
            if (_isPaused == false)
            {
                _isPaused = true;

                foreach (var objectsProvider in _objectsProviders)
                {
                    foreach (IPausable pausableObject in objectsProvider.GetPausableObjects())
                    {
                        pausableObject.Pause();
                    } 
                }
            }
        }

        public void ResumeObjects()
        {
            if (_isPaused == true)
            {
                _isPaused = false;
                foreach (var objectsProvider in _objectsProviders)
                {
                    foreach (IPausable pausableObject in objectsProvider.GetPausableObjects())
                    {
                        pausableObject.Resume();
                    } 
                }
            }
        }
    }
}