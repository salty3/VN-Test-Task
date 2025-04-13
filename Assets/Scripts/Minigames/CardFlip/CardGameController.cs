using System;
using Minigames.CardFlip.Behaviour;
using Minigames.CardFlip.Behaviour.States;
using Minigames.CardFlip.Field;
using Minigames.CardFlip.Levels;
using Minigames.CardFlip.UI.EndScreen;
using Minigames.CardFlip.UI.InfoPanel;
using Tools.Runtime;
using UnityEngine;
using UnityEngine.Events;

namespace Minigames.CardFlip
{
    public class CardGameController : CachedMonoBehaviour
    {
        public UnityEvent GameEnded { get; } = new();

        [SerializeField] private CardsFieldController _cardsFieldController;
        [SerializeField] private EndScreenController _endScreenController;
        [SerializeField] private InfoPanelController _infoPanelController;
        
        private GameplayLoopStateManager _gameplayLoopStateManager;
        
        public void StartGame(LevelData levelData)
        {
            var cardsFieldEntity = new CardsFieldEntity(levelData);
            
            var endState = new EndState(_endScreenController);
            endState.ContinueClicked.AddListener(GameEnded.Invoke);
            
            _gameplayLoopStateManager = new GameplayLoopStateManager(
                new PreparationPhaseState(levelData, cardsFieldEntity, _cardsFieldController, _infoPanelController),
                new ShowCardsState(_cardsFieldController),
                new PlayerInteractionState(levelData, _cardsFieldController, _infoPanelController),
                new ShuffleCardsState(_cardsFieldController),
                endState
            );
            
            _gameplayLoopStateManager.SwitchToState<PreparationPhaseState>();
        }
        
#if UNITY_EDITOR
        [SerializeField] private LevelData _debugLevel;
        private void Start()
        {
            if (_debugLevel != null)
            {
                Debug.LogWarning("Card game started in debug mode");
                StartGame(_debugLevel);
            }
        }
#endif

    }
}