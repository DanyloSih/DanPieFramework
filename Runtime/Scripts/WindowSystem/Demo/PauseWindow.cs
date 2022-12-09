﻿using System;
using DanPie.Framework.Pause;
using UnityEngine;
using UnityEngine.UI;

namespace DanPie.Framework.WindowSystem.Demo
{
    public class PauseWindow : WindowObject, IPauseWindow
    {
        [SerializeField] private Button _continueButton;

        public event Action OnContinue;

        protected override void OnAwake()
        {
            _continueButton.onClick.AddListener(() => OnContinue?.Invoke());
        }
    }
}
