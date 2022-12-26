using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.GameEvent
{
    public sealed class GameEventIndicatorView : MonoBehaviour
    {
        [field: SerializeField] public Image Icon { get; private set; }
        [field: SerializeField] public RectTransform IndicatorDiameter { get; private set; }
    } 
}
