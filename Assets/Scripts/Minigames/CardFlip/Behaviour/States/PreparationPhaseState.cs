using System.Linq;
using Minigames.CardFlip.Field;
using Minigames.CardFlip.Levels;
using Minigames.CardFlip.UI.InfoPanel;
using Naninovel;

namespace Minigames.CardFlip.Behaviour.States
{
    public class PreparationPhaseState : GameState
    {
        private readonly LevelData _levelData;
        private readonly IReadOnlyCardsFieldEntity _cardsFieldEntity;
        private readonly CardsFieldController _cardsFieldController;
        private readonly InfoPanelController _infoPanelController;

        public PreparationPhaseState(LevelData levelData, 
            IReadOnlyCardsFieldEntity cardsFieldEntity,
            CardsFieldController cardsFieldController,
            InfoPanelController infoPanelController)
        {
            _levelData = levelData;
            _cardsFieldEntity = cardsFieldEntity;
            _cardsFieldController = cardsFieldController;
            _infoPanelController = infoPanelController;
        }

        public override void Initialize()
        {
            InitializeAsync().Forget();
        }

        private async UniTask InitializeAsync()
        {
            var maxMatchesCount = _levelData.Cards.Count();
            var maxMismatchesCount = _levelData.MaxMismatchCount;
            
            _infoPanelController.SetMatchCount(0, maxMatchesCount);
            _infoPanelController.SetMismatchCount(0, maxMismatchesCount);
            
            await _cardsFieldController.Construct(_levelData, _cardsFieldEntity);
            _cardsFieldController.BlockInteraction();
            StateManager.SwitchToState<ShuffleCardsState>();
        }

        public override void Dispose()
        {
            _cardsFieldController.UnblockInteraction();
        }
    }
}