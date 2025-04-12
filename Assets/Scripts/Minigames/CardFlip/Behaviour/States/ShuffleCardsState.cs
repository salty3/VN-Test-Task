using Minigames.CardFlip.Field;
using Naninovel;

namespace Minigames.CardFlip.Behaviour.States
{
    public class ShuffleCardsState : GameState
    {
        private readonly CardsFieldController _cardsFieldController;
        
        public ShuffleCardsState(CardsFieldController cardsFieldController)
        {
            _cardsFieldController = cardsFieldController;
        }

        public override void Initialize()
        {
            ShuffleCards().Forget();
        }

        private async UniTask ShuffleCards()
        {
            _cardsFieldController.BlockInteraction();
            await _cardsFieldController.Shuffle();
            StateManager.SwitchToState<ShowCardsState>();
        }

        public override void Dispose()
        {
            _cardsFieldController.UnblockInteraction();
        }
    }
}