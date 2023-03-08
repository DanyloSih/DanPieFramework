using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DanPie.Framework.WindowSystem
{
    public class MessageWindow : WindowWithBackground
    {
        [SerializeField] private Button _okButton;
        [SerializeField] private TMP_Text _okButtonText;
        [SerializeField] private TMP_Text _messageText;
        
        public bool IsAccepted { get; private set; } = false;
        public TMP_Text OkButtonText => _okButtonText;
        public TMP_Text MessageText => _messageText;

        protected override void OnAwake()
        {
            base.OnAwake();
            IsAccepted = false;
            _okButton.onClick.AddListener(OnOkClicked);
        }

        protected override void OnDestroed()
        {
            base.OnDestroed();
            _okButton.onClick.RemoveListener(OnOkClicked);
        }

        protected override void OnShow()
        {
            base.OnShow();

            IsAccepted = false;
        }

        protected override void OnHide()
        {
            base.OnHide();

            if (!IsFirstHiding)
            {
                IsAccepted = true;
            }
        }

        private void OnOkClicked()
        {
            Hide();
        }
    }
}
