using UI.Common;
using UnityEngine;

namespace UI.Game
{
    public sealed class PlayerSpeedometerView : MonoBehaviour
    {
        [field: SerializeField] public TextView SpeedometerTextView { get; private set; }

        public void Init(string text) => SpeedometerTextView.Init(text);
        public void UpdateText(string text) => SpeedometerTextView.UpdateText(text);
    }
}