using DanPie.Framework.Parameters.Controllers;
using UnityEngine;

namespace DanPie.Framework.Parameters
{
    public class SliderParameterControllerFactory
        : UIParameterControllerFactory<SliderParameterController, ValueParameter>
    {
        private Vector2 _minMaxRange;

        public Vector2 MinMaxRange
        {
            get => _minMaxRange;
            set
            {
                _minMaxRange = new Vector2(Mathf.Min(value.x, value.y), Mathf.Max(value.x, value.y));
            }
        }

        public SliderParameterControllerFactory(
            Transform uiContainer,
            SliderParameterController uiControllerPrefab,
            Vector2 _initialSliderMinMaxRange) 
            : base(uiContainer, uiControllerPrefab)
        {
            MinMaxRange = _initialSliderMinMaxRange;
        }

        public SliderParameterController Create(ValueParameter parameter, Vector2 sliderMinMaxRange)
        {
            MinMaxRange = sliderMinMaxRange;
            return base.Create(parameter);
        }

        protected override SliderParameterController OnCreate(
            SliderParameterController uiInstace,
            ValueParameter parameter)
        {
            uiInstace.SetMinMaxRange(MinMaxRange);
            uiInstace.Value = parameter.Value;
            parameter.ValueChanged.AddListener((x) => uiInstace.Value = x);
            uiInstace.ValueChanged.AddListener((x) => parameter.Value = x);
            
            return uiInstace;
        }
    }
}
