﻿using DanPie.Framework.WindowSystem;
using DanPie.Framework.WindowSystem.Demo;
using UnityEngine;

namespace DanPie.Framework.Pause.Demo
{
    public class PauseInitializer : MonoBehaviour
    {
        [SerializeField] private AndroidPauseActivator _pauseActivator;
        [SerializeField] private WindowsCanvas _popupCanvas;
        [SerializeField] private PauseWindow _pauseWindowPrefab;

        protected void Awake()
        {
            if (!_popupCanvas.IsWindowExist(_pauseWindowPrefab.GetType()))
            {
                PauseWindow instance = Instantiate(_pauseWindowPrefab);
                instance.transform.SetParent(_popupCanvas.transform);
                _popupCanvas.AddUniqueWindow(instance);
            }

            _pauseActivator.Initialize(_popupCanvas, 
                (IPauseWindow)_popupCanvas.GetWindow(_pauseWindowPrefab.GetType()));
        }
    }
}
