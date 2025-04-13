using DG.Tweening;
using JetBrains.Annotations;
using Minigames.CardFlip.Field;
using Minigames.CardFlip.Levels;
using Naninovel;
using Tools.SceneManagement.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Minigames.CardFlip
{
    [InitializeAtRuntime]
    [UsedImplicitly]
    public class CardGameService : ICardGameService
    {
        private CardGameConfiguration _configuration;

        private readonly IInputManager _inputManager;
        private readonly ICameraManager _cameraManager;
        
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
            
            var canvasGroup = scene.GetRootObject<CanvasGroup>();
            canvasGroup.alpha = 0;
            await canvasGroup.DOFade(1, 1f).SetEase(Ease.OutSine).AsyncWaitForCompletion();

            var cardGameController = scene.GetRootObject<CardGameController>();

            cardGameController.StartGame(GetRandomLevel());
            
            
            var gameOperation = new UniTaskCompletionSource();
            cardGameController.GameEnded.AddListener(() => gameOperation.TrySetResult());
            
            await gameOperation.Task;
            
            await canvasGroup.DOFade(0, 1f).SetEase(Ease.OutSine).AsyncWaitForCompletion();
            
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