using UI.Common;
using UnityEngine;

namespace UI.Game
{
    public sealed class PlayerWeaponView : MonoBehaviour
    {
        [field: SerializeField] public TextView WeaponTextView { get; private set; }

        public void Init(string text) => WeaponTextView.Init(text);
        public void UpdateText(string text) => WeaponTextView.UpdateText(text);
    }
}