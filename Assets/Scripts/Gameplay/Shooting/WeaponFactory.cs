using System;
using Abstracts;
using Scriptables.Modules;
using UnityEngine;

namespace Gameplay.Shooting
{
    public static class WeaponFactory
    {
        public static FrontalTurretController CreateFrontalTurret(TurretModuleConfig config, Transform gunPointParentTransform, UnitType unitType)
        {
            return config.WeaponType switch
            {
                WeaponType.None => new FrontalNullGunController(config, gunPointParentTransform, unitType),
                WeaponType.Blaster => new FrontalBlasterController(config, gunPointParentTransform, unitType),
                WeaponType.Shotgun => new FrontalShotgunController(config, gunPointParentTransform, unitType),
                WeaponType.Minigun => new FrontalMinigunController(config, gunPointParentTransform, unitType),
                WeaponType.Railgun => new FrontalRailgunController(config, gunPointParentTransform, unitType),
                _ => throw new ArgumentOutOfRangeException(nameof(config.WeaponType), config.WeaponType, "A not-existent weapon type is provided")
            };
        }
    }
}