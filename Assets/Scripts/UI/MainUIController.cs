using Abstracts;
using UnityEngine;
using Utilities.ResourceManagement;

namespace UI
{
    public sealed class MainUIController : BaseController
    {
        public Canvas MainCanvas { get; }
        
        private readonly ResourcePath _uiCameraPath = new(Constants.Prefabs.Canvas.UICamera);
        private readonly ResourcePath _mainCanvasPath = new(Constants.Prefabs.Canvas.MainCanvas);

        public MainUIController(Transform uiPosition)
        {
            var uiCamera = ResourceLoader.LoadPrefabAsChild<Camera>(_uiCameraPath, uiPosition);
            MainCanvas = ResourceLoader.LoadPrefabAsChild<Canvas>(_mainCanvasPath, uiPosition);
            MainCanvas.worldCamera = uiCamera;
            
            AddGameObject(uiCamera.gameObject);
            AddGameObject(MainCanvas.gameObject);
        }
    }
}