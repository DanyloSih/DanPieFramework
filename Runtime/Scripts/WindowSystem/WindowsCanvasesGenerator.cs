using System;
using System.Collections.Generic;
using UnityEngine;

namespace DanPie.Framework.WindowSystem
{
    public class WindowsCanvasesCreator<T>
        where T : WindowsCanvas
    {
        private int _countOfOrdersInLayer;

        public WindowsCanvasesCreator(int countOfOrdersInLayer)
        {
            _countOfOrdersInLayer = countOfOrdersInLayer;
        }

        public List<T> CreateWindowsCanvases(int windowsCanvasesCount)
        {
            List<T> windowsCanvases = new List<T>();

            for (int i = 0; i < windowsCanvasesCount; i++)
            {
                windowsCanvases.Add(CreateWindowsCanvas(i));
            }

            return windowsCanvases;
        }

        private T CreateWindowsCanvas(int windowsCanvasId)
        {
            T windowsCanvas = new GameObject().AddComponent<T>();
            windowsCanvas.gameObject.name = $"WindowsCanvas |{windowsCanvasId}|";

            windowsCanvas.SetLayerSortOrderBounds(new Vector2Int(
                _countOfOrdersInLayer * windowsCanvasId + 1, 
                _countOfOrdersInLayer * (windowsCanvasId + 1)));

            return windowsCanvas;
        }
    }
}