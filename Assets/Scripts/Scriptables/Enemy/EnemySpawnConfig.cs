using System.Collections.Generic;
using UnityEngine;

namespace Scriptables.Enemy
{
    [CreateAssetMenu(fileName = nameof(EnemySpawnConfig), menuName = "Configs/Enemy/" + nameof(EnemySpawnConfig))]
    public sealed class EnemySpawnConfig : ScriptableObject
    {
        [field: SerializeField] public EnemyConfig Enemy { get; private set; }
        [field: SerializeField] public List<EnemyGroupSpawn> EnemyGroupsSpawnPoints { get; private set; }
    }
}