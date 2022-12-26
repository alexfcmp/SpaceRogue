using System.Collections.Generic;
using Scriptables.Modules;
using UnityEngine;

namespace Gameplay.Player.Inventory
{
    [CreateAssetMenu(fileName = nameof(PlayerInventoryConfig), menuName = "Configs/Player/" + nameof(PlayerInventoryConfig))]
    public sealed class PlayerInventoryConfig : ScriptableObject
    {
        [field: SerializeField] public EngineModuleConfig Engine { get; private set; }
        [field: SerializeField] public List<ShieldModuleConfig> Shields { get; private set; }
        [field: SerializeField] public List<TurretModuleConfig> Turrets { get; private set; }
    }
}