using UnityEngine;

namespace Scriptables.GameEvent
{
    [CreateAssetMenu(fileName = nameof(SupernovaGameEventConfig), menuName = "Configs/GameEvent/" + nameof(SupernovaGameEventConfig))]
    public sealed class SupernovaGameEventConfig : GameEventConfig
    {
        [field: SerializeField, Header("Supernova Settings"), Min(0)] public float SearchRadius { get; private set; } = 100;
        [field: SerializeField, Min(0.1f)] public float TimeToExplosionInSeconds { get; private set; } = 5;
        [field: SerializeField] public Color WarningColor { get; private set; } = Color.red;
        [field: SerializeField] public Sprite SupernovaSprite { get; private set; }
        [field: SerializeField] public Color ShockwaveColor { get; private set; } = Color.red;
        [field: SerializeField, Min(0)] public float ShockwaveSpeed { get; private set; } = 1;
        [field: SerializeField, Min(0)] public float ShockwaveRadius { get; private set; } = 100;
        [field: SerializeField, Min(0)] public float ShockwaveForce { get; private set; } = 50;
        [field: SerializeField, Min(0)] public float ShockwaveDamage { get; private set; } = 1;
    }
}