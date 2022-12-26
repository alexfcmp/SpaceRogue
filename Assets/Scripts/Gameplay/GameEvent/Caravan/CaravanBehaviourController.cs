using Abstracts;
using Gameplay.Enemy.Movement;
using Gameplay.Movement;
using UnityEngine;
using Utilities.Mathematics;
using Utilities.Unity;

namespace Gameplay.GameEvent
{
    public sealed class CaravanBehaviourController : BaseController
    {
        private const int FatalDamage = 9999;

        private readonly MovementModel _movementModel;
        private readonly CaravanView _view;
        private readonly EnemyInputController _inputController;
        private readonly Vector3 _targetPosition;

        private Vector3 _targetDirection;
        private Vector3 _currentDirection;
        private float _distance;

        public CaravanBehaviourController(MovementModel movementModel, CaravanView view, Vector3 targetPosition)
        {
            _movementModel = movementModel;
            _view = view;
            AddGameObject(_view.gameObject);
            _inputController = AddInputController();
            AddMovementController();
            _targetPosition = targetPosition;

            EntryPoint.SubscribeToUpdate(MoveToTarget);
        }

        protected override void OnDispose()
        {
            base.OnDispose();
            EntryPoint.UnsubscribeFromUpdate(MoveToTarget);
        }

        private void MoveToTarget()
        {
            GetDirectionsAndDistance();
            RotateTowardsTarget();
            Move();
        }

        private void GetDirectionsAndDistance()
        {
            _currentDirection = _view.transform.TransformDirection(Vector3.up);
            var direction = _targetPosition - _view.transform.position;
            _targetDirection = direction.normalized;
            _distance = direction.magnitude;
        }

        private void RotateTowardsTarget()
        {
            if (_targetDirection == _currentDirection)
            {
                _inputController.StopTurning();
            }
            else
            {
                HandleTurn();
            }
        }

        private void HandleTurn()
        {
            if (UnityHelper.VectorAngleLessThanAngle(_targetDirection, _currentDirection, 0))
            {
                _inputController.TurnLeft();
            }
            else
            {
                _inputController.TurnRight();
            }
        }

        private void Move()
        {
            if (_distance < _view.transform.localScale.MaxVector3CoordinateOnPlane())
            {
                _view.Init(new(FatalDamage));
                _view.TakeDamage(_view);
                Dispose();
                return;
            }
            _inputController.Accelerate();
        }

        private EnemyInputController AddInputController()
        {
            var inputController = new EnemyInputController();
            AddController(inputController);
            return inputController;
        }

        private EnemyMovementController AddMovementController()
        {
            var (horizontalInput, verticalInput) = _inputController;
            var movementController = new EnemyMovementController(horizontalInput, verticalInput, _movementModel, _view);
            AddController(movementController);
            return movementController;
        }
    }
}