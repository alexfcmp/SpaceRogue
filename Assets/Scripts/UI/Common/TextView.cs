using TMPro;
using UnityEngine;

namespace UI.Common
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public sealed class TextView : MonoBehaviour
    {
        private TextMeshProUGUI _text;

        public void Init(string text)
        {
            _text = GetComponent<TextMeshProUGUI>();
            _text.text = text;
        }

        public void UpdateText(string text)
        {
            _text.text = text;
        }
    }
}