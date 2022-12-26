using System.Collections.Generic;
using Abstracts;
using Scriptables.Modules;

namespace Gameplay.Player.Inventory
{
    public sealed class PlayerInventoryController : BaseController
    {
        private readonly PlayerInventoryConfig _config;

        public EngineModuleConfig Engine => _config.Engine;
        public List<TurretModuleConfig> Turrets => _config.Turrets;

        public PlayerInventoryController(PlayerInventoryConfig config)
        {
            _config = config;
        }
    }
}