using Gameplay.GameEvent;
using Gameplay.Movement;
using Scriptables.Health;
using UnityEngine;

namespace Scriptables.GameEvent
{
    [CreateAssetMenu(fileName = nameof(CaravanConfig), menuName = "Configs/Caravan/" + nameof(CaravanConfig))]
    public sealed class CaravanConfig : ScriptableObject
    {
        [field: SerializeField] public CaravanView CaravanView { get; private set; }
        [field: SerializeField] public MovementConfig Movement { get; private set; }
        [field: SerializeField] public HealthConfig Health { get; private set; }
        [field: SerializeField] public ShieldConfig Shield { get; private set; }
    }
}