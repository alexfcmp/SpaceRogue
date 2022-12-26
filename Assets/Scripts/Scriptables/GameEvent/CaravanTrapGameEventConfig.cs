using UnityEngine;

namespace Scriptables.GameEvent
{
    [CreateAssetMenu(fileName = nameof(CaravanTrapGameEventConfig), menuName = "Configs/GameEvent/" + nameof(CaravanTrapGameEventConfig))]
    public sealed class CaravanTrapGameEventConfig : BaseCaravanGameEventConfig
    {
        [field: SerializeField, Header("CaravanTrap Settings"), Min(0)] public float AlertRadius { get; private set; } = 70;
    }
}