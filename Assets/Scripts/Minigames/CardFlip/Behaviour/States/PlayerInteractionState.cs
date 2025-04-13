using System.Linq;
using Minigames.CardFlip.Field;
using Minigames.CardFlip.Levels;
using Minigames.CardFlip.UI.InfoPanel;

namespace Minigames.CardFlip.Behaviour.States
{
    public class PlayerInteractionState : GameState
    {
        //private readonly IReadOnlyLevelEntity _levelEntity;
        private readonly CardsFieldController _cardsFieldController;
        

        private int _matchesCount;
        private readonly int _maxMatchesCount;

        private int _mismatchesCount;
        private readonly int _maxMismatchesCount;

        private readonly InfoPanelController _infoPanelController;
        
        public PlayerInteractionState(
            LevelData levelData,
            CardsFieldController cardsFieldController, 
            InfoPanelController infoPanelController)
        {
            _cardsFieldController = cardsFieldController;
            _infoPanelController = infoPanelController;
            _maxMatchesCount = levelData.Cards.Count();
            _maxMismatchesCount = levelData.MaxMismatchCount;
            _matchesCount = 0;
            _mismatchesCount = 0;
        }
        
        public override void Initialize()
        {
            _cardsFieldController.Matched.AddListener(OnMatch);
            _cardsFieldController.Mismatched.AddListener(OnMismatch);
            _infoPanelController.ShuffleButtonClicked.AddListener(OnShuffleButtonClicked);
            
            _cardsFieldController.UnblockInteraction();
            
            //There should be some reactive way to update the UI
            _infoPanelController.SetMatchCount(_matchesCount, _maxMatchesCount);
            _infoPanelController.SetMismatchCount(_mismatchesCount, _maxMismatchesCount);
        }

        public override void Dispose()
        {
            _cardsFieldController.BlockInteraction();
            
            _infoPanelController.ShuffleButtonClicked.RemoveListener(OnShuffleButtonClicked);
            _cardsFieldController.Matched.RemoveListener(OnMatch);
            _cardsFieldController.Mismatched.RemoveListener(OnMismatch);
        }
        
        private void OnShuffleButtonClicked()
        {
            StateManager.SwitchToState<ShuffleCardsState>();
        }
        
        private void OnMatch(string pairId)
        {
            _matchesCount++;
            _cardsFieldController.CompletePair(pairId);
            
            
            _infoPanelController.SetMatchCount(_matchesCount, _maxMatchesCount);
            if (_matchesCount == _maxMatchesCount)
            {
                StateManager.SwitchToState<EndState>();
            }
        }
        
        private void OnMismatch()
        {
            _mismatchesCount++;
            
            _infoPanelController.SetMismatchCount(_mismatchesCount, _maxMismatchesCount);
            if (_mismatchesCount >= _maxMismatchesCount)
            {
                StateManager.SwitchToState<EndState>();
            }
        }
    }
}