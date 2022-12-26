using Abstracts;
using Gameplay.Damage;
using Scriptables.GameEvent;
using UnityEngine;
using Utilities.Mathematics;

namespace Gameplay.GameEvent
{
    public sealed class CometController : BaseController
    {
        private readonly CometConfig _config;
        private readonly CometView _view;
        private readonly Rigidbody2D _rigidbody;
        private readonly Vector3 _movementDirection;
        private readonly float _speed;
        private float _remainingLifeTime;

        public bool IsDestroyed { get; private set; } = false;

        public CometView View => _view;

        public CometController(CometConfig config, CometView view, Vector3 movementDirection)
        {
            _config = config;
            _movementDirection = movementDirection;
            _view = view;
            AddGameObject(_view.gameObject);
            _rigidbody = _view.GetComponent<Rigidbody2D>();
            _speed = RandomPicker.PickRandomBetweenTwoValues(_config.MinSpeed, _config.MaxSpeed, new());
            _remainingLifeTime = config.LifeTimeInSeconds;

            var damageModel = new DamageModel(config.Damage);
            _view.Init(damageModel);
            _view.CollisionEnter += Dispose;

            EntryPoint.SubscribeToUpdate(Move);
        }

        protected override void OnDispose()
        {
            base.OnDispose();
            _view.CollisionEnter -= Dispose;
            EntryPoint.UnsubscribeFromUpdate(Move);
            IsDestroyed = true;
        }

        private void Move(float deltaTime)
        {
            if (_remainingLifeTime <= 0)
            {
                Dispose();
                return;
            }

            _rigidbody.AddForce(_movementDirection.normalized * _speed, ForceMode2D.Force);

            _remainingLifeTime -= deltaTime;
        }
    }
}