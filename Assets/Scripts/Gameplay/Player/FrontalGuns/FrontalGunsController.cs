using System.Collections.Generic;
using Abstracts;
using Gameplay.Shooting;
using Scriptables.Modules;
using UI.Game;
using UnityEngine;
using Utilities.Reactive.SubscriptionProperty;


namespace Gameplay.Player.FrontalGuns
{
    public sealed class FrontalGunsController : BaseController
    {
        private readonly SubscribedProperty<bool> _primaryFireInput;
        private readonly SubscribedProperty<bool> _changeWeaponInput;
        private readonly List<TurretModuleConfig> _turretConfigs;
        private readonly List<FrontalTurretController> _turretControllers;

        private readonly PlayerWeaponView _playerWeaponView;

        private int _currentTurret;

        public FrontalGunsController(SubscribedProperty<bool> primaryFireInput, SubscribedProperty<bool> changeWeaponInput, List<TurretModuleConfig> turretConfigs, PlayerView playerView)
        {
            _primaryFireInput = primaryFireInput;
            _changeWeaponInput = changeWeaponInput;
            _turretConfigs = turretConfigs;
            
            _turretControllers = new List<FrontalTurretController>();
            
            foreach (var config in _turretConfigs)
            {
                InitializeTurret(config, playerView.transform);
            }

            _playerWeaponView = GameUIController.PlayerWeaponView;
            _playerWeaponView.Init(_turretConfigs[0].WeaponType.ToString());

            _primaryFireInput.Subscribe(HandleFiring);
            _changeWeaponInput.Subscribe(ChangeWeapon);
        }

        protected override void OnDispose()
        {
            _primaryFireInput.Unsubscribe(HandleFiring);
            _changeWeaponInput.Unsubscribe(ChangeWeapon);
        }

        private void HandleFiring(bool isFiring)
        {
            if (isFiring)
            {
                _turretControllers[_currentTurret].CommenceFiring(); 
            }
        }

        private void ChangeWeapon(bool isChange)
        {
            if (isChange)
            {
                _currentTurret = (_currentTurret + 1) % _turretConfigs.Count;
                _playerWeaponView.UpdateText(_turretConfigs[_currentTurret].WeaponType.ToString());
            }
        }

        private void InitializeTurret(TurretModuleConfig turretConfig, Transform transform)
        {
            var turretController = WeaponFactory.CreateFrontalTurret(turretConfig, transform, UnitType.Player);
            AddController(turretController);
            _turretControllers.Add(turretController);
        }
    }
}