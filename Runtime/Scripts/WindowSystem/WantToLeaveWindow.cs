using UnityEngine;
using UnityEngine.UI;

namespace DanPie.Framework.WindowSystem
{
    public class WantToLeaveWindow : PauseWindow
    {
        [SerializeField] private Button _yesButton;

        protected override void OnAwake()
        {
            base.OnAwake();
            _yesButton.onClick.AddListener(OnYesClicked);
        }

        private void OnYesClicked()
        {
            Application.Quit();
        }
    }
}
