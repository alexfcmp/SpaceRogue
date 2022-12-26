using Abstracts;
using Scriptables;
using UnityEngine;
using Utilities.ResourceManagement;

namespace Gameplay.Background
{
    public sealed class BackgroundController : BaseController
    {
        private const int MaskCoefficient = 1;

        private readonly ResourcePath _configPath = new(Constants.Configs.Background.BackgroundConfig);
        private readonly ResourcePath _viewPath = new(Constants.Prefabs.Stuff.Background);

        private readonly BackgroundConfig _config;
        private readonly BackgroundView _view;
        private readonly Transform _cameraTransform;

        private readonly InfiniteSprite _backParalax;
        private readonly InfiniteSprite _midParalax;
        private readonly InfiniteSprite _foreParalax;

        private readonly NebulaEffect _nebulaBackEffect;
        private readonly NebulaEffect _nebulaForeEffect;
        private readonly NebulaEffect _nebulaMaskEffect;

        public BackgroundController()
        {
            _config = ResourceLoader.LoadObject<BackgroundConfig>(_configPath);
            _view = LoadView<BackgroundView>(_viewPath);
            _cameraTransform = UnityEngine.Camera.main!.transform;

            _backParalax = new(_cameraTransform, _view.BackSpriteRenderer, _config.BackCoefficient);
            _midParalax = new(_cameraTransform, _view.MidSpriteRenderer, _config.MidCoefficient);
            _foreParalax = new(_cameraTransform, _view.ForeSpriteRenderer, _config.ForeCoefficient);

            _nebulaBackEffect = new(_cameraTransform, _view.NebulaBackParticleSystem.transform, _config.NebulaBackCoefficient);
            _nebulaForeEffect = new(_cameraTransform, _view.NebulaForeParticleSystem.transform, _config.NebulaForeCoefficient);
            _nebulaMaskEffect = new(_cameraTransform, _view.NebulaMaskParticleSystem.transform, MaskCoefficient);

            EntryPoint.SubscribeToLateUpdate(PlayAllEffects);
        }

        protected override void OnDispose()
        {
            EntryPoint.UnsubscribeFromLateUpdate(PlayAllEffects);
        }

        private void PlayAllEffects()
        {
            _backParalax.Play();
            _midParalax.Play();
            _foreParalax.Play();

            _nebulaBackEffect.Play();
            _nebulaForeEffect.Play();
            _nebulaMaskEffect.Play();
        }
    }
}