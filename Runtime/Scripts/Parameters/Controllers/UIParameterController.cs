using UnityEngine;

namespace DanPie.Framework.Parameters.Controllers
{
    public class UIParameterController : MonoBehaviour
    {
        [SerializeField] private TextAdapter _nameLabel;

        public string PanelName { get => _nameLabel.Text; set => _nameLabel.Text = value; }
    }
}