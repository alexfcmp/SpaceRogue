using System;
using UnityEngine;

namespace Gameplay.Shooting
{
    [CreateAssetMenu(fileName = nameof(ShotgunWeaponConfig), menuName = "Configs/Weapons/" + nameof(ShotgunWeaponConfig))]
    public sealed class ShotgunWeaponConfig : SpecificWeaponConfig
    {
        [field: SerializeField] public ProjectileConfig ShotgunProjectile { get; private set; }
        [field: SerializeField, Min(1)] public int PelletCount { get; private set; } = 3;
        [field: SerializeField, Range(0, 180)] public int SprayAngle { get; private set; } = 20;
    }
}