using System.Collections.Generic;
using UnityEngine;

namespace Scriptables.Space
{
    [CreateAssetMenu(fileName = nameof(PlanetSpawnConfig), menuName = "Configs/Space/" + nameof(PlanetSpawnConfig))]
    public sealed class PlanetSpawnConfig : ScriptableObject
    {
        [field: SerializeField] public List<WeightConfig<PlanetConfig>> WeightConfigs { get; private set; }
    }
}