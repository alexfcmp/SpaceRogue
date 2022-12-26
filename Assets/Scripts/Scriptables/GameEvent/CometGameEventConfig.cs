using UnityEngine;

namespace Scriptables.GameEvent
{
    [CreateAssetMenu(fileName = nameof(CometGameEventConfig), menuName = "Configs/GameEvent/" + nameof(CometGameEventConfig))]
    public sealed class CometGameEventConfig : GameEventConfig
    {
        [field: SerializeField, Header("Comet Settings")] public CometConfig CometConfig { get; private set; }
    }
}