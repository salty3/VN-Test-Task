using DG.Tweening;
using Minigames.CardFlip.Field;
using Minigames.CardFlip.Levels;
using Naninovel;
using Tools.SceneManagement.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Minigames.CardFlip
{
    [InitializeAtRuntime]
    public class CardGameService : ICardGameService
    {
        private CardGameConfiguration _configuration;

        private IInputManager _inputManager;
        private ICameraManager _cameraManager;
        
        public CardGameService(IInputManager inputManager, ICameraManager cameraManager)
        {
            _inputManager = inputManager;
            _cameraManager = cameraManager;
        }

        public async UniTask PlayGame(AsyncToken asyncToken = default)
        {
            _inputManager.ProcessInput = false;
            _cameraManager.Camera.enabled = false;
            _cameraManager.UICamera.enabled = false;
            
            var scene = _configuration.GameScene;
            await scene.LoadSceneAsync(LoadSceneMode.Additive);

            var cardGameController = scene.GetRootObject<CardGameController>();

            cardGameController.StartGame(GetRandomLevel());
            
            
            var gameOperation = new UniTaskCompletionSource();
            cardGameController.GameEnded.AddListener(() => gameOperation.TrySetResult());
            
            await gameOperation.Task;
            
            await scene.UnloadSceneAsync();
            
            _inputManager.ProcessInput = true;
            _cameraManager.Camera.enabled = true;
            _cameraManager.UICamera.enabled = true;
        }
        
        private LevelData GetRandomLevel()
        {
            return _configuration.Levels[UnityEngine.Random.Range(0, _configuration.Levels.Length)];
        }
        
        public UniTask InitializeServiceAsync()
        {
            _configuration = Engine.GetConfiguration<CardGameConfiguration>();
            return default;
        }

        public void ResetService() { }
        public void DestroyService() { }
    }
}