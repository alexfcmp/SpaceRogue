using UnityEngine;

namespace Gameplay.Background
{
    public abstract class ParallaxEffect
    {
        protected readonly Transform _cameraTransform;
        protected readonly Transform _transform;

        protected readonly float _coefficient;

        protected Vector3 _lastCameraPosition;

        public ParallaxEffect(Transform cameraTransform, Transform transform, float coefficient)
        {
            _cameraTransform = cameraTransform;
            _transform = transform;
            _coefficient = coefficient;
            _lastCameraPosition = _cameraTransform.position;
            
            transform.position = new(_lastCameraPosition.x, _lastCameraPosition.y, 0);
        }

        public void Play()
        {
            _transform.position += (_cameraTransform.position - _lastCameraPosition) * _coefficient;
            OptionalExecute();
            _lastCameraPosition = _cameraTransform.transform.position;
        }

        protected virtual void OptionalExecute() { }
    } 
}
