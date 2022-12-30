namespace DanPie.Framework.Pause
{
    public class PauseController : IPauseController
    {
        private IPausableObjectsProvider _objectsProvider;
        private bool _isPaused = false;

        public PauseController(IPausableObjectsProvider objectsProvider)
        {
            _objectsProvider = objectsProvider;
        }

        public void PauseObjects()
        {
            if (_isPaused == false)
            {
                _isPaused = true;

                foreach (IPausable pausableObject in _objectsProvider.GetPausableObjects())
                {
                    pausableObject.Pause();
                }
            }
        }

        public void ResumeObjects()
        {
            if (_isPaused == true)
            {
                _isPaused = false;
                foreach (IPausable pausableObject in _objectsProvider.GetPausableObjects())
                {
                    pausableObject.Resume();
                }
            }
        }
    }
}