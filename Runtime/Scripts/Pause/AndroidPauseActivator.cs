using System.Collections.Generic;
using System.Linq;
using DanPie.Framework.Common;
using DanPie.Framework.WindowSystem;
using UnityEngine;

namespace DanPie.Framework.Pause
{

    public class AndroidPauseActivator : MultipleInitializableMonoBehaviour, IPauseActivator
    {
        [SerializeField] private KeyCode _backKeyCode;

        private WindowsCanvas _pauseWindowCanvas;
        private IPauseWindow _pauseWindowInstance;
        private IPauseController _pauseController;

        public bool Enabled { get => enabled; set => enabled = value; }

        public void Initialize(
            WindowsCanvas pauseWindowCanvas,
            IPauseWindow pauseWindowInstance,
            IPauseController pauseController)
        {
            _pauseController = pauseController;
            _pauseWindowCanvas = pauseWindowCanvas;
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
                HideHidableWindows();
                _pauseWindowCanvas.ShowAlso(_pauseWindowInstance.GetType());
                _pauseController.PauseObjects();
            }
        }

        private void HideHidableWindows()
        {
            IEnumerable<IWindow> windows =
                _pauseWindowCanvas.GetSortedVisibleWindows().Where(x => !(x is IUnhideableFromPause));

            foreach (IWindow window in windows)
            {
                window.Hide();
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
            List<IWindow> windows = _pauseWindowCanvas.GetSortedVisibleWindows();

            if (windows == null || windows.Count == 0)
            {
                SetPause(true);
                return;
            }

            if (windows.Last().GetType() == _pauseWindowInstance.GetType())
            {
                Resume();
                return;
            }

            for (int i = windows.Count - 1; i >= 0; i--)
            {
                var window = windows[i];

                if (window is IUnhideableFromPause)
                {
                    if (!((IUnhideableFromPause)window).IsPauseWindowCanBeShown())
                    {
                        return;
                    }
                }
                else
                {
                    window.Hide();
                    return;
                }
                
                if (i == 0)
                {
                    SetPause(true);
                    return;
                }
            }
        }
    }
}
