using System;
using UnityEngine;

namespace Gameplay.Shooting
{
    [CreateAssetMenu(fileName = nameof(MinigunWeaponConfig), menuName = "Configs/Weapons/" + nameof(MinigunWeaponConfig))]
    public sealed class MinigunWeaponConfig : SpecificWeaponConfig
    {
        [field: SerializeField] public ProjectileConfig MinigunProjectile { get; private set; }
        [field: SerializeField, Range(0, 180)] public float SprayAngle { get; internal set; } = 1.0f;
        [field: SerializeField, Range(0, 180)] public float MaxSprayAngle { get; private set; } = 20.0f;
        [field: SerializeField, Min(0.1f)] public float OverheatCoolDown { get; private set; } = 2.0f;
        [field: SerializeField, Min(1)] public int TimeToOverheat { get; private set; } = 5;
    }
}