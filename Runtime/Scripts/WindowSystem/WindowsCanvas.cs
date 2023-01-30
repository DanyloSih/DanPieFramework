using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DanPie.Framework.WindowSystem
{

    public class WindowsCanvas : MonoBehaviour
	{
        private class WindowData
        {
            public int SortingOrder;
            public IWindow Window;

            public WindowData(int sortingOrder, IWindow window)
            {
                SortingOrder = sortingOrder;
                Window = window;
            }
        }

        [SerializeField] private Vector2Int _layerSortOrderBounds = new Vector2Int(1, 1000);

        private int _currentSortingOrder = 0;
        private List<WindowData> _windowsData = new List<WindowData>();

        public event Action<WindowsCanvas> SortingOrderChanged;

        public List<IWindow> GetSortedVisibleWindows()
        {
            List<IWindow> windows = new List<IWindow>();
            foreach (WindowData windowData in GetSortedVisibleWindowsData())
            {
                windows.Add(windowData.Window);
            }
            return windows;
        }

        public IWindow GetOrCreateWindow(Type type, Func<IWindow> windowFactoryMethod)
        {
            if (!IsWindowExist(type))
            {
                AddUniqueWindow(windowFactoryMethod.Invoke());
            }

            return GetWindow(type);
        }

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
                throw new ArgumentException("This windowData is already on the canvas, if you want to use it " +
                    $"call the {nameof(GetWindow)} method.");
            }

            _windowsData.Add(new WindowData(0, window));
            window.Hide();
        }

        public T GetWindow<T>()
            where T : IWindow
        {
            return (T)GetWindow(typeof(T));
        }

        public IWindow GetWindow(Type windowType)
        {
            return GetWindowData(windowType).Window;
        }

        public bool IsWindowExist(Type windowType)
        {
            return _windowsData.Any((x) => x.Window.GetType() == windowType);
        }

        public void FocusOnWindow(Type windowType)
        {
            WindowData windowData = GetWindowData(windowType);
            if (!windowData.Window.IsVisible)
            {
                throw new ArgumentException("To focus windowData, it must be visible!");
            }
            var sortedWindows = GetSortedVisibleWindowsData();
            sortedWindows.Remove(windowData);
            sortedWindows.Add(windowData);

            ResetSortingOrders(sortedWindows);
        }

        public int GetWindowSortOrder(Type windowType)
        {
            WindowData windowData = GetWindowData(windowType);

            if (!windowData.Window.IsVisible)
            {
                throw new ArgumentException("To get windowData SortOrder, it must be visible!");
            }

            return windowData.SortingOrder;
        }

        public void SwapWindows(Type aType, Type bType)
        {
            WindowData aInstance = GetWindowData(aType);
            WindowData bInstance = GetWindowData(bType);

            if (!aInstance.Window.IsVisible || !bInstance.Window.IsVisible)
            {
                throw new ArgumentException("To swap windowsData, they must both be visible!");
            }

            List<WindowData> windowsData = GetSortedVisibleWindowsData();
            int aIndex = windowsData.IndexOf(aInstance);
            int bIndex = windowsData.IndexOf(bInstance);
            windowsData[aIndex] = bInstance;
            windowsData[bIndex] = aInstance;

            ResetSortingOrders(windowsData);
        }

        public void SetLayerSortOrderBounds(Vector2Int layerSortOrderBounds)
        {
            _layerSortOrderBounds = layerSortOrderBounds;
            ResetSortingOrders(GetSortedVisibleWindowsData());
        }

        public void RemoveWindow(Type windowType)
        {
            _windowsData.Remove(GetWindowData(windowType));
        }

        public void ShowOnly(Type windowType)
        {
            HideAll();
            WindowData windowData = GetWindowData(windowType);
            windowData.SortingOrder = _currentSortingOrder;
            _currentSortingOrder++;
            windowData.Window.Show(this);
        }

        public void ShowAlso(Type windowType)
        {
            WindowData windowData = GetWindowData(windowType);
            windowData.SortingOrder = _currentSortingOrder;
            _currentSortingOrder++;
            windowData.Window.Show(this);

            if (_currentSortingOrder >= _layerSortOrderBounds.y)
            {
                ResetSortingOrders(GetSortedVisibleWindowsData());
            }
        }

        public IWindow GetFocusedWindow()
        {
            List<WindowData> windowsData = GetSortedVisibleWindowsData();
            if (windowsData.Count == 0)
            {
                return null;
            }
            else
            {
                return windowsData[windowsData.Count - 1].Window;
            }
        }

        public void HideAll()
        {
            _currentSortingOrder = _layerSortOrderBounds.x;
            foreach (WindowData windowData in _windowsData)
            {
                if (windowData.Window.IsVisible)
                {
                    windowData.Window.Hide();
                }
            }
        }

        protected void Awake()
        {
            _currentSortingOrder = _layerSortOrderBounds.x;
        }

        private void ResetSortingOrders(List<WindowData> activeWindows)
        {
            _currentSortingOrder = _layerSortOrderBounds.x;

            foreach (WindowData windowData in activeWindows)
            {
                windowData.SortingOrder = _currentSortingOrder;
                _currentSortingOrder++;
            }
            SortingOrderChanged?.Invoke(this);
        }

        private List<WindowData> GetSortedVisibleWindowsData()
        {
            List<WindowData> active = _windowsData.Where((x) => x.Window.IsVisible).ToList();
            active.Sort((x, y) => x.SortingOrder - y.SortingOrder);
            return active;
        }

        private WindowData GetWindowData(Type windowType)
        {
            WindowData windowData = _windowsData.FirstOrDefault((x) => x.Window.GetType() == windowType);
            if (windowData == null)
            {
                throw new ArgumentException($"Window with windowType {windowType} not yet exist, if you want to interact with it " +
                    $"from this canvas, first add it using the {nameof(AddUniqueWindow)} method.");
            }
            return windowData;
        }
    }
}