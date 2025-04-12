using Minigames.CardFlip.Field;
using Minigames.CardFlip.Levels;
using Naninovel;

namespace Minigames.CardFlip.Behaviour.States
{
    public class PreparationPhaseState : GameState
    {
        private readonly LevelData _levelData;
        private readonly IReadOnlyCardsFieldEntity _cardsFieldEntity;
        private readonly CardsFieldController _cardsFieldController;

        public PreparationPhaseState(LevelData levelData, 
            IReadOnlyCardsFieldEntity cardsFieldEntity,
            CardsFieldController cardsFieldController)
        {
            _levelData = levelData;
            _cardsFieldEntity = cardsFieldEntity;
            _cardsFieldController = cardsFieldController;
        }

        public override void Initialize()
        {
            InitializeAsync().Forget();
        }

        private async UniTask InitializeAsync()
        {
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