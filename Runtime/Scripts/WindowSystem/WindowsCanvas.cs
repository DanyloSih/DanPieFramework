using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DanPie.Framework.WindowSystem
{

    public class WindowsCanvas : MonoBehaviour
	{
        [SerializeField] private Vector2Int _layerSortOrderBounds = new Vector2Int(1, 1000);

        private int _currentSortingOrder = 0;
        private List<IWindow> _windows = new List<IWindow>();

        public T GetOrCreateWindow<T>(Func<T> windowFactoryMethod)
            where T : IWindow
        {
            if (!IsWindowExist(typeof(T)))
            {
                AddUniqueWindow(windowFactoryMethod.Invoke());
            }

            return (T)GetWindow(typeof(T));
        }

        public void AddUniqueWindow(IWindow window)
        {
            if (IsWindowExist(window.GetType()))
            {
                throw new ArgumentException("This window is already on the canvas, if you want to use it " +
                    $"call the {nameof(GetWindow)} method.");
            }

            _windows.Add(window);
            window.Hide();
        }

        public T GetWindow<T>()
            where T : IWindow
        {
            return (T)GetWindow(typeof(T));
        }

        public IWindow GetWindow(Type windowType)
        {
            IWindow result = _windows.FirstOrDefault((x) => x.GetType() == windowType);
            if (result == null)
            {
                throw new ArgumentException($"Window with windowType {windowType} not yet exist, if you want to interact with it " +
                    $"from this canvas, first add it using the {nameof(AddUniqueWindow)} method.");
            }
            return result;
        }

        public bool IsWindowExist(Type windowType)
        {
            return _windows.Any((x) => x.GetType() == windowType);
        }

        public void SetLayerSortOrderBounds(Vector2Int layerSortOrderBounds)
        {
            _layerSortOrderBounds = layerSortOrderBounds;
            ResetSortingOrders();
        }

        public void RemoveWindow(Type windowType)
        {
            _windows.Remove(GetWindow(windowType));
        }

        public void ShowOnly(Type windowType)
        {
            HideAll();
            GetWindow(windowType).Show(_currentSortingOrder);
            _currentSortingOrder++;
        }

        public void ShowAlso(Type windowType)
        {
            GetWindow(windowType).Show(_currentSortingOrder);
            _currentSortingOrder++;

            if (_currentSortingOrder >= _layerSortOrderBounds.y)
            {
                ResetSortingOrders();
            }
        }

        public IWindow GetLastVisibleWindow()
        {
            List<IWindow> windows = GetSortedVisibleWindows();
            if (windows.Count == 0)
            {
                return null;
            }
            else
            {
                return windows.Last();
            }
        }

        public void HideAll()
        {
            _currentSortingOrder = _layerSortOrderBounds.x;
            foreach (IWindow window in _windows)
            {
                if (window.IsVisible)
                {
                    window.Hide();
                }
            }
        }

        protected void Awake()
        {
            _currentSortingOrder = _layerSortOrderBounds.x;
        }

        private void ResetSortingOrders()
        {
            _currentSortingOrder = _layerSortOrderBounds.x;
            List<IWindow> active = GetSortedVisibleWindows();

            foreach (IWindow window in active)
            {
                window.Show(_currentSortingOrder);
                _currentSortingOrder++;
            }
        }

        private List<IWindow> GetSortedVisibleWindows()
        {
            List<IWindow> active = _windows.Where((x) => x.IsVisible).ToList();
            active.Sort((x, y) => Mathf.Clamp(x.SortOrder - y.SortOrder, -1, 1));
            return active;
        }
    }
}