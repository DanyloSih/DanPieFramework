using UnityEngine;
using UnityEngine.Events;

namespace DanPie.Framework.Common
{
    public interface IValueAdapter
    {
        float Value { get; set; }
        UnityEvent<float> ValueChanged { get; }
    }
}