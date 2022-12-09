using UnityEngine;

namespace DanPie.Framework.WindowSystem
{

    [RequireComponent(typeof(Canvas))]
    public abstract class WindowObject : MonoBehaviour, IWindow
    {
        private Canvas _canvas;

        public bool IsVisible { get; private set; }
        public int SortOrder { get; private set; }

        public void Hide()
        {
            _canvas.enabled = false;
            IsVisible = false;
            OnHide();
        }

        public void Show(int order)
        {
            SortOrder = order;
            _canvas.sortingOrder = order;
            _canvas.enabled = true;
            IsVisible = true;
            OnShow();
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
