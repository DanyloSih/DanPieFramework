using DanPie.Framework.Parameters.Controllers;
using UnityEngine;

namespace DanPie.Framework.Parameters
{
    public class ButtonParameterControllerFactory 
        : UIParameterControllerFactory<ButtonParameterController, TriggerableParameter>
    {
        public ButtonParameterControllerFactory(
            Transform uiContainer,
            ButtonParameterController uiControllerPrefab)
            : base(uiContainer, uiControllerPrefab)
        {
        }

        protected override ButtonParameterController OnCreate(
            ButtonParameterController uiInstace,
            TriggerableParameter parameter)
        {
            uiInstace.Clicked.AddListener(parameter.Trigger);
            parameter.Triggered.AddListener(uiInstace.Click);
            return uiInstace;
        }
    }
}
