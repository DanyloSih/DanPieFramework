using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace DanPie.Framework.Parameters.Controllers
{
    public class ButtonParameterController : UIParameterController
    {
        [SerializeField] private Button _button;

        public UnityEvent Clicked = new UnityEvent();

        public void Click() 
            => _button.onClick.Invoke();

        protected void Awake()
        {
            _button.onClick.AddListener(() => Clicked.Invoke());
        }
    }
}
