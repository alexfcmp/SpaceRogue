using Abstracts;
using Scriptables.Modules;
using UnityEngine;

namespace Gameplay.Shooting
{
    public sealed class FrontalBlasterController : FrontalTurretController
    {
        private readonly BlasterWeaponConfig _weaponConfig;

        public FrontalBlasterController(TurretModuleConfig config, Transform gunPointParentTransform, UnitType unitType) : base(config, gunPointParentTransform, unitType)
        {
            var blasterConfig = config.SpecificWeapon as BlasterWeaponConfig;
            _weaponConfig = blasterConfig 
                ? blasterConfig 
                : throw new System.Exception("Wrong config type was provided");
        }

        public override void CommenceFiring()
        {
            if (IsOnCooldown)
            {
                return;
            }

            var projectile = ProjectileFactory.CreateProjectile();
            AddController(projectile);

            CooldownTimer.Start();
        }
    }
}