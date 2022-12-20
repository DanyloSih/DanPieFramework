using DanPie.Framework.Common;
using DanPie.Framework.Parameters.Controllers;
using UnityEngine;

namespace DanPie.Framework.Parameters
{
    public class ToggleParameterControllerFactory : UIParameterControllerFactory<ToggleParameterController, ActivableParameter>
    {
        public ToggleParameterControllerFactory(
            Transform uiContainer,
            ToggleParameterController togglePanelPrefab)
            : base(uiContainer, togglePanelPrefab)
        {
        }

        protected override ToggleParameterController OnCreate(ToggleParameterController uiController, ActivableParameter parameter)
        {
            parameter.Activated.AddListener(() => uiController.IsOn = true);
            parameter.Deactivated.AddListener(() => uiController.IsOn = false);
            uiController.Toggled.AddListener((b) => OnToggle(b, parameter));
            return uiController;
        }

        private void OnToggle(bool toggleState, IActivable activable)
        {
            if (toggleState)
            {
                activable.Activate();
            }
            else
            {
                activable.Deactivate();
            }
        }
    }
}
