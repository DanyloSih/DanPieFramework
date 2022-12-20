using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace DanPie.Framework.Parameters.Controllers
{
    public class ToggleParameterController : UIParameterController
    {
        [SerializeField] private Toggle _toggle;

        public UnityEvent<bool> Toggled = new UnityEvent<bool>();

        public bool IsOn { get => _toggle.isOn; set => _toggle.isOn = value; }

        protected void Awake()
        {
            _toggle.onValueChanged.AddListener((x) => Toggled.Invoke(x));
        }
    }
}
