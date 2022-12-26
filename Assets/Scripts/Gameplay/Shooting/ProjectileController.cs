using Abstracts;
using Gameplay.Damage;
using UnityEngine;

namespace Gameplay.Shooting
{
    public sealed class ProjectileController : BaseController
    {
        private readonly ProjectileConfig _config;
        private readonly ProjectileView _view;
        private readonly Vector3 _movementDirection;
        private float _remainingLifeTime;
        
        public ProjectileController(ProjectileConfig config, ProjectileView view, Vector3 movementDirection, UnitType unitType)
        {
            _config = config;
            _movementDirection = movementDirection;
            _view = view;
            AddGameObject(_view.gameObject);
            _remainingLifeTime = config.LifeTime;
            
            var damageModel = new DamageModel(config.DamageAmount, unitType);
            _view.Init(damageModel);
            if (config.IsDestroyedOnHit) _view.CollisionEnter += Dispose;

            EntryPoint.SubscribeToUpdate(TickDown);
        }

        protected override void OnDispose()
        {
            _view.CollisionEnter -= Dispose;
            EntryPoint.UnsubscribeFromUpdate(TickDown);
        }

        private void TickDown(float deltaTime)
        {
            if (_remainingLifeTime <= 0)
            {
                Dispose();
                return;
            }

            var transform = _view.transform;
            transform.position += _movementDirection * (_config.Speed * 2 * deltaTime);
            
            _remainingLifeTime -= deltaTime;
        }
    }
}