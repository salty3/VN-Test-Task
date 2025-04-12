using System;
using Minigames.CardFlip.Field;
using Naninovel;

namespace Minigames.CardFlip.Behaviour.States
{
    public class ShowCardsState : GameState
    {
        private readonly CardsFieldController _cardsFieldController;
        
        private readonly TimeSpan _showCardsTime = TimeSpan.FromSeconds(3f);
        
        public ShowCardsState(CardsFieldController cardsFieldController)
        {
            _cardsFieldController = cardsFieldController;
        }

        public override void Initialize()
        {
            ShowCards().Forget();
        }

        public override void Dispose()
        {
            _cardsFieldController.UnblockInteraction();
        }
        
        private async UniTask ShowCards()
        {
            _cardsFieldController.BlockInteraction();
            await _cardsFieldController.ShowCardsFor(_showCardsTime);
            StateManager.SwitchToState<PlayerInteractionState>();
        }
    }
}