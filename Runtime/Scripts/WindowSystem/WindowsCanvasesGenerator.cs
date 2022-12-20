using System;
using System.Collections.Generic;
using UnityEngine;

namespace DanPie.Framework.WindowSystem
{
    public class WindowsCanvasesCreator
    {
        private int _countOfOrdersInLayer;

        public WindowsCanvasesCreator(int countOfOrdersInLayer)
        {
            _countOfOrdersInLayer = countOfOrdersInLayer;
        }

        public List<WindowsCanvas> CreateWindowsCanvases(int windowsCanvasesCount)
        {
            List<WindowsCanvas> windowsCanvases = new List<WindowsCanvas>();

            for (int i = 0; i < windowsCanvasesCount; i++)
            {
                windowsCanvases.Add(CreateWindowsCanvas(i));
            }

            return windowsCanvases;
        }

        private WindowsCanvas CreateWindowsCanvas(int windowsCanvasId)
        {
            WindowsCanvas windowsCanvas = new GameObject().AddComponent<WindowsCanvas>();
            windowsCanvas.gameObject.name = $"WindowsCanvas |{windowsCanvasId}|";

            windowsCanvas.SetLayerSortOrderBounds(new Vector2Int(
                _countOfOrdersInLayer * windowsCanvasId + 1, 
                _countOfOrdersInLayer * (windowsCanvasId + 1)));

            return windowsCanvas;
        }
    }
}