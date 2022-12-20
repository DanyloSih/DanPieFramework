using UnityEngine;
using UnityEngine.UI;

namespace DanPie.Framework.Parameters.Controllers
{
    public class UITextAdapter : TextAdapter
    {
        [SerializeField] private Text _text;

        public override string Text { get => _text.text; set => _text.text = value; }
    }
}