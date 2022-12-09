using UnityEngine;

namespace DanPie.Framework.WindowSystem.Demo
{
    public class WindowsSwitcher : MonoBehaviour
    {
        [Header("Base")]
        [SerializeField] private WindowsCanvas _baseCanvas;
        [SerializeField] private WindowObject _baseWindow1;
        [SerializeField] private WindowObject _baseWindow2;

        [Header("Pop Up")]
        [SerializeField] private WindowsCanvas _popupCanvas;
        [SerializeField] private WindowObject _popupWindow1;
        [SerializeField] private WindowObject _popupWindow2;

        protected void Start()
        {
            _baseCanvas.AddUniqueWindow(_baseWindow1);
            _baseCanvas.AddUniqueWindow(_baseWindow2);

            _popupCanvas.AddUniqueWindow(_popupWindow1);    
            _popupCanvas.AddUniqueWindow(_popupWindow2);    
        }

        protected void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _baseCanvas.ShowAlso(_baseWindow1.GetType());
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _baseCanvas.ShowAlso(_baseWindow2.GetType());
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                _popupCanvas.ShowAlso(_popupWindow1.GetType());    
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                _popupCanvas.ShowAlso(_popupWindow2.GetType());    
            } 
            if (Input.GetKeyDown(KeyCode.C))
            {
                _baseCanvas.HideAll();    
                _popupCanvas.HideAll();    
            }
        }
    }
}
