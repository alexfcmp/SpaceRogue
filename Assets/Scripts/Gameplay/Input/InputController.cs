using Abstracts;
using UnityEngine;
using Utilities.Reactive.SubscriptionProperty;
using Utilities.ResourceManagement;

namespace Gameplay.Input
{
    public class InputController : BaseController
    {
        private readonly ResourcePath _viewPrefabPath = new(Constants.Prefabs.Input.KeyboardInput);
        private readonly BaseInputView _view;

        public InputController(
            SubscribedProperty<Vector3> mousePositionInput,
            SubscribedProperty<float> verticalInput,
            SubscribedProperty<float> horizontalInput,
            SubscribedProperty<bool> primaryFireInput)
        {
            _view = LoadView<BaseInputView>(_viewPrefabPath);
            _view.Init(mousePositionInput, verticalInput, horizontalInput, primaryFireInput);
        }

    }
}