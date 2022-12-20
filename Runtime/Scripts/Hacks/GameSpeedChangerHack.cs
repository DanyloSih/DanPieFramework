using DanPie.Framework.Common;
using DanPie.Framework.Parameters;
using UnityEngine;

namespace DanPie.Framework.Hacks
{
    public class GameSpeedChangerHack : ValueParameter, IResettable
    {
        private float _initialValue;

        public GameSpeedChangerHack(string parameterName, float initialValue) 
            : base(initialValue)
        {
            Name = parameterName;
            _initialValue = initialValue;
        }

        public override string Name { get; set; }

        public void ResetObject()
        {
            Value = _initialValue;
        }

        protected override void OnValueChanged()
        {
            Time.timeScale = Value;
        }
    }
}
