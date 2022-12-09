using UnityEngine;

namespace DanPie.Framework.WindowSystem
{
    [RequireComponent(typeof(Canvas))]
    public abstract class WindowObject : MonoBehaviour, IWindow
    {
        private Canvas _canvas;
        private bool _isHiding;
        private bool _isShowing;

        public bool IsVisible { get; private set; }
        public int SortOrder { get; private set; }

        public void Hide()
        {
            if (_isHiding)
            {
                return;
            }
            _isHiding = true;
            _canvas.enabled = false;
            IsVisible = false;
            OnHide();
            _isHiding = false;
        }

        public void Show(int order)
        {
            if (_isShowing)
            {
                return;
            }
            _isShowing = true;
            SortOrder = order;
            _canvas.sortingOrder = order;
            _canvas.enabled = true;
            IsVisible = true;
            OnShow();
            _isShowing = false;
        }

        protected void Awake()
        {
            _canvas = GetComponent<Canvas>();
            OnAwake();
        }

        protected virtual void OnAwake() { }
        protected virtual void OnShow() { }
        protected virtual void OnHide() { }
    }
}
