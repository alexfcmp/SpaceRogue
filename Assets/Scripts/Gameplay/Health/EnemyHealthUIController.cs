using Abstracts;
using UI.Game;
using UnityEngine;
using Utilities.Reactive.SubscriptionProperty;
using Utilities.Unity;

namespace Gameplay.Health
{
    public sealed class EnemyHealthUIController : BaseController
    {
        private const float HealthBarOffset = 5;

        private readonly Collider2D _collider;
        private readonly HealthStatusBarView _enemyStatusBarView;
        private readonly UnityEngine.Camera _camera;
        private readonly float _scaleFactor;

        private readonly SubscribedProperty<bool> _isVisible = new();

        public EnemyHealthUIController(HealthController healthController, UnitView view)
        {
            _camera = UnityEngine.Camera.main;
            _enemyStatusBarView = healthController.StatusBarView;
            _enemyStatusBarView.gameObject.SetActive(false);
            _collider = view.GetComponent<Collider2D>();
            _scaleFactor = GameUIController.EnemyHealthBars.GetComponentInParent<Canvas>().scaleFactor;

            _isVisible.Subscribe(ShowHealthBar);
            EntryPoint.SubscribeToUpdate(FollowEnemy);
        }

        protected override void OnDispose()
        {
            _isVisible.Unsubscribe(ShowHealthBar);
            EntryPoint.UnsubscribeFromUpdate(FollowEnemy);            
        }

        private void FollowEnemy()
        {
            if(_collider == null)
            {
                return;
            }

            _isVisible.Value = UnityHelper.IsObjectVisible(_camera, _collider.bounds);

            if (!_isVisible.Value)
            {
                return;
            }

            var position = _camera.WorldToScreenPoint(_collider.transform.position + Vector3.up * HealthBarOffset);
            position = new Vector3(position.x - Screen.width / 2, position.y - Screen.height / 2, 0);
            var finalPosition = new Vector3(position.x / _scaleFactor, position.y / _scaleFactor, 0);

            _enemyStatusBarView.GetComponent<RectTransform>().anchoredPosition = finalPosition;
        }

        private void ShowHealthBar(bool isVisible)
        {
            _enemyStatusBarView.gameObject.SetActive(isVisible);
        }
    }
}