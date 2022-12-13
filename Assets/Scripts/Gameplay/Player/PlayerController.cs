using Abstracts;
using Gameplay.Health;
using Gameplay.Input;
using Gameplay.Movement;
using Gameplay.Player.FrontalGuns;
using Gameplay.Player.Inventory;
using Gameplay.Player.Movement;
using Scriptables;
using Scriptables.Health;
using Scriptables.Modules;
using System;
using System.Collections.Generic;
using UI.Game;
using UnityEngine;
using Utilities.Reactive.SubscriptionProperty;
using Utilities.ResourceManagement;
using Utilities.Unity;

namespace Gameplay.Player
{
    public class PlayerController : BaseController
    {
        public PlayerView View => _view;

        private readonly ResourcePath _configPath = new(Constants.Configs.Player.PlayerConfig);
        private readonly ResourcePath _viewPath = new(Constants.Prefabs.Gameplay.Player);
        private readonly ResourcePath _crosshairPrefabPath = new(Constants.Prefabs.Stuff.Crosshair);

        private readonly PlayerConfig _config;
        private readonly PlayerView _view;

        private readonly SubscribedProperty<Vector3> _mousePositionInput = new();
        private readonly SubscribedProperty<float> _verticalInput = new();
        private readonly SubscribedProperty<float> _horizontalInput = new();
        private readonly SubscribedProperty<bool> _primaryFireInput = new();

        private const byte MaxCountOfPlayerSpawnTries = 10;
        private const float PlayerSpawnClearanceRadius = 40.0f;

        public event Action PlayerDestroyed = () => { };

        public PlayerController()
        {
            _config = ResourceLoader.LoadObject<PlayerConfig>(_configPath);
            _view = LoadView<PlayerView>(_viewPath, GetPlayerSpawnPosition());

            var inputController = new InputController(_mousePositionInput, _verticalInput, _horizontalInput, _primaryFireInput);
            AddController(inputController);

            var inventoryController = AddInventoryController(_config.Inventory);
            var movementController = AddMovementController(_config.Movement, _view);
            var frontalGunsController = AddFrontalGunsController(inventoryController.Turrets, _view);
            var healthController = AddHealthController(_config.HealthConfig, _config.ShieldConfig);
            AddCrosshair();
        }

        private HealthController AddHealthController(HealthConfig healthConfig, ShieldConfig shieldConfig)
        {
            var healthController = new HealthController(healthConfig, shieldConfig, GameUIController.PlayerStatusBarView, _view);
            healthController.SubscribeToOnDestroy(Dispose);
            healthController.SubscribeToOnDestroy(OnPlayerDestroyed);
            AddController(healthController);
            return healthController;
        }

        private PlayerInventoryController AddInventoryController(PlayerInventoryConfig config)
        {
            var inventoryController = new PlayerInventoryController(config);
            AddController(inventoryController);
            return inventoryController;
        }

        private PlayerMovementController AddMovementController(MovementConfig movementConfig, PlayerView view)
        {
            var movementController = new PlayerMovementController(_mousePositionInput, _verticalInput, _horizontalInput, movementConfig, view);
            AddController(movementController);
            return movementController;
        }

        private FrontalGunsController AddFrontalGunsController(List<TurretModuleConfig> turretConfigs, PlayerView view)
        {
            var frontalGunsController = new FrontalGunsController(_primaryFireInput, turretConfigs, view);
            AddController(frontalGunsController);
            return frontalGunsController;
        }

        private Vector3 GetPlayerSpawnPosition()
        {
            Vector3 startPlayerPosition;
            int tryCount = 0;
            do
            {
                startPlayerPosition = RandomizePlayerStartPosition();
                tryCount++;
            }
            while (UnityHelper.IsAnyObjectAtPosition(startPlayerPosition, PlayerSpawnClearanceRadius) && tryCount <= MaxCountOfPlayerSpawnTries);

            if (tryCount > MaxCountOfPlayerSpawnTries)
            {
                //TODO Clear position for player spawn when too many tries happened
            }

            return startPlayerPosition;
        }

        private Vector3 RandomizePlayerStartPosition()
        {
            var random = new System.Random();
            //TODO Change according to map boundaries
            return new Vector3(random.Next(-400, 400), random.Next(-400, 400), 0);
        }

        private void AddCrosshair()
        {
            var crosshairView = ResourceLoader.LoadPrefab(_crosshairPrefabPath);
            var viewTransform = _view.transform;
            var crosshair = UnityEngine.Object.Instantiate(
                crosshairView,
                viewTransform.position + _view.transform.TransformDirection(Vector3.up * (viewTransform.localScale.y + 20f)),
                viewTransform.rotation
            );
            crosshair.transform.parent = _view.transform;
            AddGameObject(crosshair);
        }

        public void OnPlayerDestroyed()
        {
            PlayerDestroyed();
        }
    }
}