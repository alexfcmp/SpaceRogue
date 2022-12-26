using Gameplay.Player;
using Scriptables.Enemy;
using UnityEngine;

namespace Gameplay.Enemy
{
    public sealed class EnemyFactory
    {
        private readonly EnemyConfig _config;
        
        public EnemyFactory(EnemyConfig config)
        {
            _config = config;
        }

        public EnemyController CreateEnemy(Vector3 spawnPosition, PlayerController playerController) 
            => new(_config, CreateEnemyView(spawnPosition), playerController, playerController.View.transform);

        public EnemyController CreateEnemy(Vector3 spawnPosition, PlayerController playerController, Transform target) 
            => new(_config, CreateEnemyView(spawnPosition), playerController, target);

        private EnemyView CreateEnemyView(Vector3 spawnPosition) =>
            Object.Instantiate(_config.Prefab, spawnPosition, Quaternion.identity);
    }
}