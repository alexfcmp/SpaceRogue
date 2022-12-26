using Gameplay.Shooting;
using UnityEngine;

namespace Scriptables.Modules
{
    [CreateAssetMenu(fileName = nameof(TurretModuleConfig), menuName = "Configs/Modules/" + nameof(TurretModuleConfig))]
    public sealed class TurretModuleConfig : BaseModuleConfig
    {
        [field: SerializeField] public ProjectileConfig ProjectileConfig { get; private set; }
        [field: SerializeField] public WeaponType WeaponType { get; private set; }
        [field: SerializeField] public SpecificWeaponConfig SpecificWeapon { get; private set; }
    }
}