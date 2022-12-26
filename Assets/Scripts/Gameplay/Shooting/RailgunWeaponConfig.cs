using UnityEngine;

namespace Gameplay.Shooting
{
    [CreateAssetMenu(fileName = nameof(RailgunWeaponConfig), menuName = "Configs/Weapons/" + nameof(RailgunWeaponConfig))]
    public sealed class RailgunWeaponConfig : SpecificWeaponConfig
    {
        [field: SerializeField] public ProjectileConfig RailgunProjectile { get; private set; }
    }
}