using DanPie.Framework.Common;
using DanPie.Framework.Hacks;
using DanPie.Framework.Parameters.Controllers;
using UnityEngine;

namespace DanPie.Framework.Parameters
{
    public class ParametersRegister 
    {
        private Transform _parametersContainer;
        private ToggleParameterController _toggleParameterControllerPrefab;
        private ButtonParameterController _buttonParameterControllerPrefab;
        private SliderParameterController _sliderParameterControllerPrefab;

        private Resetter _resetter = new Resetter();
        private ToggleParameterControllerFactory _toggleParameterControllerFactory;
        private ButtonParameterControllerFactory _buttonParameterControllerFactory;
        private SliderParameterControllerFactory _sliderParameterControllerFactory;

        public ParametersRegister(
            Transform parametersContainer,
            ToggleParameterController toggleParameterControllerPrefab,
            ButtonParameterController buttonParameterControllerPrefab,
            SliderParameterController sliderParameterControllerPrefab)
        {
            _parametersContainer = parametersContainer;
            _toggleParameterControllerPrefab = toggleParameterControllerPrefab;
            _buttonParameterControllerPrefab = buttonParameterControllerPrefab;
            _sliderParameterControllerPrefab = sliderParameterControllerPrefab;

            InitializeHacksUIFactories();
        }

        private void InitializeHacksUIFactories()
        {
            _toggleParameterControllerFactory =
                new ToggleParameterControllerFactory(_parametersContainer, _toggleParameterControllerPrefab);
            _buttonParameterControllerFactory =
                new ButtonParameterControllerFactory(_parametersContainer, _buttonParameterControllerPrefab);
            _sliderParameterControllerFactory =
                new SliderParameterControllerFactory(_parametersContainer, _sliderParameterControllerPrefab, new Vector2(0, 2));
        }

        public void ResetResettableParameters()
        {
            _resetter.Reset();
        }

        public virtual void RegisterParameter(Parameter parameter)
        {
            if (parameter is IResettable)
            {
                _resetter.AddResettableObject((IResettable)parameter);
            } 
            if (parameter is TriggerableParameter)
            {
                _buttonParameterControllerFactory.Create((TriggerableParameter)parameter);
            }
            if (parameter is ValueParameter)
            {
                _sliderParameterControllerFactory.Create((ValueParameter)parameter);
            }
            if (parameter is ActivableParameter)
            {
                _toggleParameterControllerFactory.Create((ActivableParameter)parameter);
            }
        }
    }
}
