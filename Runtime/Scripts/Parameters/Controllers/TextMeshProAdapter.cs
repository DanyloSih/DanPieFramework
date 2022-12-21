using TMPro;
using UnityEngine;

namespace DanPie.Framework.Parameters.Controllers
{
    public class TextMeshProAdapter : TextAdapter
    {
        [SerializeField] private TMP_Text _text;

        public override string Text { get => _text.text; set => _text.text = value; }
    }
}