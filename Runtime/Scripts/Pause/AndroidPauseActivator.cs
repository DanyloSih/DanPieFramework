using DanPie.Framework.Common;
using DanPie.Framework.WindowSystem;
using UnityEngine;

namespace DanPie.Framework.Pause
{
    public class AndroidPauseActivator : MultipleInitializableMonoBehaviour, IPauseActivator
    {
        [SerializeField] private KeyCode _backKeyCode;

        private WindowsCanvas _popupCanvas;
        private IPauseWindow _pauseWindowInstance;
        private IPauseController _pauseController;

        public bool Enabled { get => enabled; set => enabled = value; }

        public void Initialize(
            WindowsCanvas popupCanvas,
            IPauseWindow pauseWindowInstance,
            IPauseController pauseController)
        {
            _pauseController = pauseController;
            _popupCanvas = popupCanvas;
            _pauseWindowInstance = pauseWindowInstance;
            _pauseWindowInstance.OnContinue += Resume;
            IsInitialized = true;
        }

        protected void OnDestroy()
        {
            _pauseWindowInstance.OnContinue -= Resume;
        }

        protected void OnApplicationFocus(bool focus)
        {
            if (Enabled)
            {
                SetPause(!focus);
            }
        }

        protected void OnApplicationPause(bool pause)
        {
            if (Enabled)
            {
                SetPause(pause);
            }
        }

        protected void Update()
        {
            if (Input.GetKeyDown(_backKeyCode))
            {
                OnBackButtonPressed();
            }
        }

        private void SetPause(bool pause)
        {
            CheckIsInitialized();
            if (pause)
            {
                _popupCanvas.ShowOnly(_pauseWindowInstance.GetType());
                _pauseController.PauseObjects();
            }
        }

        private void Resume()
        {
            _pauseWindowInstance.Hide();
            _pauseController.ResumeObjects();
        }

        private void OnBackButtonPressed()
        {
            CheckIsInitialized();
            IWindow window = _popupCanvas.GetFirstVisibleWindow();
            if (window != null)
            {
                if (window.GetType() == _pauseWindowInstance.GetType())
                {
                    _pauseController.ResumeObjects();
                }
                window.Hide();
            }
            else
            {
                _popupCanvas.ShowOnly(_pauseWindowInstance.GetType());
                _pauseController.PauseObjects();
            }
        }
    }
}
