using System;
using System.Collections.Generic;
using Abstracts;
using Gameplay.Enemy;
using Gameplay.Enemy.Behaviour;
using Gameplay.Movement;
using Scriptables.Health;
using Scriptables.Modules;
using UnityEngine;

namespace Scriptables.Enemy
{
    [CreateAssetMenu(fileName = nameof(EnemyConfig), menuName = "Configs/Enemy/" + nameof(EnemyConfig))]
    public sealed class EnemyConfig : ScriptableObject, IIdentityItem<string>
    {
        [field: SerializeField] public string Id { get; private set; } = Guid.NewGuid().ToString();
        [field: SerializeField] public EnemyView Prefab { get; private set; }
        [field: SerializeField] public List<WeightConfig<TurretModuleConfig>> TurretConfigs { get; private set; }
        [field: SerializeField] public MovementConfig Movement { get; private set; }
        [field: SerializeField] public EnemyBehaviourConfig Behaviour { get; private set; }
        [field: SerializeField] public HealthConfig Health { get; private set; }
        [field: SerializeField] public ShieldConfig Shield { get; private set; }
    }
}