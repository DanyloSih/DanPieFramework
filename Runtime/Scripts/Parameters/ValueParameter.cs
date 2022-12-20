using DanPie.Framework.Common;
using UnityEngine.Events;

namespace DanPie.Framework.Parameters
{
    public abstract class ValueParameter : Parameter, IValueAdapter
    {
        private float _value;
        private bool _isChanging = false;

        protected ValueParameter(float initialValue)
        {
            Value = initialValue;
        }

        public UnityEvent<float> ValueChanged { get; } = new UnityEvent<float>();
        public float Value
        {
            get => _value;
            set
            {
                if (_isChanging == false)
                {
                    _isChanging = true;
                    if (value != _value)
                    {
                        _value = value;
                        OnValueChanged();
                        ValueChanged.Invoke(_value);
                    }
                    _isChanging = false;
                } 
            }
        }

        protected abstract void OnValueChanged();
    }
}
