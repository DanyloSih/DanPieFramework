using System;
using DanPie.Framework.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DanPie.Framework.WindowSystem
{
    [RequireComponent(typeof(Canvas))]
    public abstract class WindowObject : LayoutsUpdater, IWindow
    {
        private Type _myType;
        private int _hidesCounter = 0;
        private Canvas _canvas;
        private bool _isHiding;
        private bool _isShowing;

        public bool IsVisible { get; private set; }
        public int SortOrder { get; private set; }
        public WindowsCanvas UsingCanvas { get; private set; }
        public bool IsFirstHiding { get => _hidesCounter == 1; }

        [ContextMenu("Hide")]
        public void Hide()
        {
            _hidesCounter = Mathf.Clamp(_hidesCounter + 1, 0, 2);
            
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

        public void Show(WindowsCanvas windowsCanvas)
        {
            if (windowsCanvas == null)
            {
                throw new ArgumentNullException();
            }

            if (_isShowing)
            {
                return;
            }

            _isShowing = true;
            IsVisible = true;
            _canvas.enabled = true;
            UpdateWindowsCanvas(windowsCanvas);
            OnShow();
            _isShowing = false;
        }

        protected void Awake()
        {
            _canvas = GetComponent<Canvas>();
            _myType = GetType();
            OnAwake();
        }

        protected void OnDestroy()
        {
            UnsubscribeFromWindowsCanvas();
            OnDestroed();
        }

        protected virtual void OnAwake() { }

        protected virtual void OnShow()
        {
            UpdateLayouts();
        }

        protected virtual void OnHide() { }

        protected virtual void OnDestroed() { }

        private void UpdateWindowsCanvas(WindowsCanvas windowsCanvas)
        {
            if (UsingCanvas != windowsCanvas)
            {
                UnsubscribeFromWindowsCanvas();
                SubscribeToNewWindowsCanvas(windowsCanvas);
            }
        }

        private void SubscribeToNewWindowsCanvas(WindowsCanvas windowsCanvas)
        {
            UsingCanvas = windowsCanvas;
            UsingCanvas.SortingOrderChanged += UpdateSortingOrder;
            transform.SetParent(UsingCanvas.transform);

            if (!UsingCanvas.IsWindowExist(_myType))
            {
                UsingCanvas.AddUniqueWindow(this);
                UsingCanvas.FocusOnWindow(_myType);
            }
            else
            {
                UpdateSortingOrder(windowsCanvas);
            }
        }

        private void UnsubscribeFromWindowsCanvas()
        {
            if (UsingCanvas != null)
            {
                UsingCanvas.SortingOrderChanged -= UpdateSortingOrder;

                if (UsingCanvas.IsWindowExist(_myType))
                {
                    UsingCanvas.RemoveWindow(_myType);
                }
            }
        }

        private void UpdateSortingOrder(WindowsCanvas windowsCanvas)
        {
            if (IsVisible)
            {
                SortOrder = windowsCanvas.GetWindowSortOrder(_myType);
            }
            _canvas.sortingOrder = SortOrder;
        }
    }
}
