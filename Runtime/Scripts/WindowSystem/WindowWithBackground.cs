using UnityEngine;

namespace DanPie.Framework.WindowSystem
{
    public class WindowWithBackground : WindowObject
    {
        [SerializeField] private BackgroundWindow _backgroundWindowPreafab;

        private BackgroundWindow _backgroundWindow;

        protected BackgroundWindow BackgroundWindow 
        {
            get
            {
                if (_backgroundWindowPreafab == null || UsingCanvas == null)
                {
                    return null;
                }

                _backgroundWindow = _backgroundWindow == null
                    ? UsingCanvas.GetOrCreateWindow(() => Instantiate(_backgroundWindowPreafab))
                    : _backgroundWindow;
                _backgroundWindow.Hide();
                return _backgroundWindow;
            }
        }

        protected override void OnShow()
        {
            base.OnShow();
            var background = BackgroundWindow;
            if (background != null)
            {
                UsingCanvas.ShowAlso(background.GetType());
                UsingCanvas.FocusOnWindow(GetType());
            }
        }

        protected override void OnHide()
        {
            var background = BackgroundWindow;
            if (background != null)
            {
                background.Hide();
            }
            base.OnHide();
        }
    }
}
