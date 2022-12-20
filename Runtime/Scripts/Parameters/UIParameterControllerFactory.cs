using DanPie.Framework.Parameters.Controllers;
using UnityEngine;

namespace DanPie.Framework.Parameters
{
    /// <summary>
    /// Responsible for creating the UI controller for the parameter
    /// </summary>
    /// <typeparam name="TUIController"></typeparam>
    /// <typeparam name="TParameter"></typeparam>
    public abstract class UIParameterControllerFactory<TUIController, TParameter>
        where TUIController: UIParameterController
        where TParameter : Parameter
    {
        private Transform _uiContainer;
        private TUIController _uiControllerPrefab;

        protected UIParameterControllerFactory(Transform uiContainer, TUIController uiControllerPrefab)
        {
            _uiContainer = uiContainer;
            _uiControllerPrefab = uiControllerPrefab;
        }

        public TUIController Create(TParameter parameter)
        {
            TUIController uiInstance = MonoBehaviour.Instantiate(_uiControllerPrefab.gameObject)
                .GetComponent<TUIController>();
            uiInstance.transform.SetParent(_uiContainer, false);
            uiInstance.PanelName = parameter.Name;
            return OnCreate(uiInstance, parameter);
        }

        protected abstract TUIController OnCreate(TUIController uiInstace, TParameter parameter);
    }
}
