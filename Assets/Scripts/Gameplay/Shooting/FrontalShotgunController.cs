using Abstracts;
using Scriptables.Modules;
using UnityEngine;
using Utilities.Mathematics;
using Random = System.Random;

namespace Gameplay.Shooting
{
    public sealed class FrontalShotgunController : FrontalTurretController
    {
        private readonly ShotgunWeaponConfig _weaponConfig;

        public FrontalShotgunController(TurretModuleConfig config, Transform gunPointParentTransform, UnitType unitType) : base(config, gunPointParentTransform, unitType)
        {
            var shotgunConfig = config.SpecificWeapon as ShotgunWeaponConfig;
            _weaponConfig = shotgunConfig 
                ? shotgunConfig 
                : throw new System.Exception("Wrong config type was provided");
        }

        public override void CommenceFiring()
        {
            if (IsOnCooldown)
            {
                return;
            }

            FireMultipleProjectiles(_weaponConfig.PelletCount, _weaponConfig.SprayAngle);

            CooldownTimer.Start();
        }

        private void FireMultipleProjectiles(int count, float sprayAngle)
        {
            var minimumAngle = -sprayAngle / 2;
            var singlePelletAngle = sprayAngle / count;
            Random r = new Random();

            for (int i = 0; i < count; i++)
            {
                var minimumPelletAngle = minimumAngle + i * singlePelletAngle;
                var maximumPelletAngle = minimumAngle + (i + 1) * singlePelletAngle;

                var pelletAngle = RandomPicker.PickRandomBetweenTwoValues(minimumPelletAngle, maximumPelletAngle, r);
                Vector3 pelletVector = (pelletAngle + 90).ToVector3();
                //TODO check 90 degrees turn
                var projectile = ProjectileFactory.CreateProjectile(pelletVector);
                AddController(projectile);
            }
        }
    }   
}