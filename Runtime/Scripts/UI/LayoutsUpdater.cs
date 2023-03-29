using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DanPie.Framework.UI
{
    public class LayoutsUpdater : MonoBehaviour
    {
        public void UpdateLayouts()
        {
            var compoents = GetComponentsInChildren<LayoutGroup>();
            Canvas.ForceUpdateCanvases();
            foreach (var item in compoents)
            {
                item.enabled = false;
                item.enabled = true;
            }
            Canvas.ForceUpdateCanvases();
        }
    }
}