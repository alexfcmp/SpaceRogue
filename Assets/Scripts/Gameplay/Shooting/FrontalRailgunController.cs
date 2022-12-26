using Abstracts;
using Scriptables.Modules;
using UnityEngine;

namespace Gameplay.Shooting
{
    public sealed class FrontalRailgunController : FrontalTurretController
    {
        private readonly RailgunWeaponConfig _weaponConfig;

        public FrontalRailgunController(TurretModuleConfig config, Transform gunPointParentTransform, UnitType unitType) : base(config, gunPointParentTransform, unitType)
        {
            var railgunConfig = config.SpecificWeapon as RailgunWeaponConfig;
            _weaponConfig = railgunConfig 
                ? railgunConfig 
                : throw new System.Exception("wrong config type was provided");
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
