using UnityEngine;
using UnityEngine.UI;

namespace DanPie.Framework.WindowSystem
{
    public class YesNoDialog : WindowWithBackground
    {
        [SerializeField] private Button _yesButton;
        [SerializeField] private Button _noButton;

        protected override void OnAwake()
        {
            base.OnAwake();
            _yesButton.onClick.AddListener(OnYesClicked);
            _noButton.onClick.AddListener(OnNoClicked);
        }

        protected override void OnDestroed()
        {
            base.OnDestroed();
            _yesButton.onClick.RemoveListener(OnYesClicked);
            _noButton.onClick.RemoveListener(OnNoClicked);
        }

        protected virtual void OnYesClicked() { }

        protected virtual void OnNoClicked() { }
    }
}
