using System.Collections.Generic;
using UnityEngine;

namespace DanPie.Framework.WindowSystem
{
    public class WindowsCanvasesCreator : MonoBehaviour
    {
        [Min(1)]
        [SerializeField] private int _countOfOrdersInLayer;

        private List<WindowsCanvas> CreateWindowsCanvases(int windowsCanvasesCount)
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
            WindowsCanvas windowsCanvas = new GameObject($"WindowsCanvas n.{windowsCanvasId}").AddComponent<WindowsCanvas>();
            windowsCanvas.SetLayerSortOrderBounds(
                new Vector2Int(_countOfOrdersInLayer * windowsCanvasId + 1, _countOfOrdersInLayer * (windowsCanvasId + 1)));
            return windowsCanvas;
        }
    }
}