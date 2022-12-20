using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace DanPie.Framework.Parameters.Controllers
{
    public class SliderParameterController : UIParameterController
    {
        [SerializeField] private TextAdapter _valueLabel;
        [SerializeField] private Slider _slider;
        
        public UnityEvent<float> ValueChanged { get; } = new UnityEvent<float>();
        public float Value 
        { 
            get => _slider.value;
            set 
            {
                _slider.value = value;
                _valueLabel.Text = _slider.value.ToString();
            } 
        }

        public void SetMinMaxRange(Vector2 minMaxRange)
        {
            _slider.minValue = Mathf.Min(minMaxRange.x, minMaxRange.y);
            _slider.maxValue = Mathf.Max(minMaxRange.x, minMaxRange.y);
        }

        protected void Awake()
        {
            _slider.onValueChanged.AddListener((x) => ValueChanged.Invoke(x));
        }

    }
}
