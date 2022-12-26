using System;
using UnityEngine;

namespace Gameplay.Shooting
{
    [CreateAssetMenu(fileName = nameof(BlasterWeaponConfig), menuName = "Configs/Weapons/" + nameof(BlasterWeaponConfig))]
    public sealed class BlasterWeaponConfig : SpecificWeaponConfig
    {
        [field: SerializeField] public ProjectileConfig BlasterProjectile { get; private set; }
        [field: SerializeField, Range(0, 180)] public int SprayAngle { get; private set; } = 0;
    }
}