using Gameplay.GameEvent;
using UnityEngine;

namespace Scriptables.GameEvent
{
    public abstract class GameEventConfig : ScriptableObject
    {
        [field: SerializeField, Header("Base Settings")] public GameEventType GameEventType { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField, Min(0)] public float IndicatorDiameter { get; private set; } = 500;
        [field: SerializeField] public bool IsRecurring { get; private set; }
        [field: SerializeField, Min(0.1f)] public float ResponseTimeInSeconds { get; private set; } = 0.1f;
        [field: SerializeField, Range(0.01f, 1f)] public float Chance { get; private set; } = 1;
    }
}