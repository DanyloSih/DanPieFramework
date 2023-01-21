using System;
using DanPie.Framework.Pause;
using UnityEngine;
using UnityEngine.UI;

namespace DanPie.Framework.WindowSystem
{

    public class PauseWindow : WindowWithBackground, IPauseWindow
    {
        [SerializeField] private Button _continueButton;

        public event Action OnContinue;

        protected override void OnAwake()
        {
            _continueButton.onClick.AddListener(() => OnContinue?.Invoke());
        }

        protected override void OnHide()
        {
            OnContinue?.Invoke();
            base.OnHide();
        }
    }
}
