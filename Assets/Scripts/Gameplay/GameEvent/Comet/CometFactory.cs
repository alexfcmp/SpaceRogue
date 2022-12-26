using Scriptables.GameEvent;
using UnityEngine;

namespace Gameplay.GameEvent
{
    public sealed class CometFactory
    {
        private readonly CometConfig _config;

        public CometFactory(CometConfig cometConfig)
        {
            _config = cometConfig;
        }

        public CometController CreateComet(Vector3 position, Vector3 direction) => new(_config, CreateCometView(position), _config.CometView.transform.TransformDirection(direction));

        private CometView CreateCometView(Vector3 position)
        {
            var cometView = Object.Instantiate(_config.CometView, position, Quaternion.identity);
            cometView.transform.localScale *= _config.Size;
            if(cometView.TryGetComponent(out TrailRenderer trailRenderer))
            {
                trailRenderer.widthMultiplier += _config.Size;
            }
            return cometView;
        }
    }
}