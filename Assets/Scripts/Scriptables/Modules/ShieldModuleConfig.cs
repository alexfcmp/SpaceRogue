using UnityEngine;

namespace Scriptables.Modules
{
    [CreateAssetMenu(fileName = nameof(ShieldModuleConfig), menuName = "Configs/Modules/" + nameof(ShieldModuleConfig))]
    public sealed class ShieldModuleConfig : BaseModuleConfig
    {
        [field: SerializeField, Min(1f)] public float ShieldAmount { get; private set; }
        [field: SerializeField, Min(0.1f)] public float Cooldown { get; private set; }
    }
}