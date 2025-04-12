using System;
using System.Collections.Generic;
using System.Linq;
using Minigames.CardFlip.Card;
using Minigames.CardFlip.Levels;
using Naninovel;
using Tools.Runtime;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Minigames.CardFlip.Field
{
    public class CardsFieldController : MonoBehaviour
    {
        [SerializeField] private CardsFieldView _view;

        private CardController _selectedController;

        private List<CardController> _cardControllers;
        
        public UnityEvent<string> Matched { get; } = new();
        public UnityEvent Mismatched { get; } = new();
        
        private LevelData _levelData;

        public async UniTask Construct(LevelData levelData, IReadOnlyCardsFieldEntity cardsFieldEntity)
        {
            _levelData = levelData;
            _cardControllers = cardsFieldEntity.Cards.ToList().ConvertAll(CreateCardController);
            await UniTask.Delay(TimeSpan.FromSeconds(_view.GridMoveDuration));
        }
        
        public void BlockInteraction()
        {
            foreach (var cardPresenter in _cardControllers)
            {
                cardPresenter.BlockInteraction();
            }
        }
        
        public void UnblockInteraction()
        {
            foreach (var cardPresenter in _cardControllers)
            {
                cardPresenter.UnblockInteraction();
            }
        }

        private void OnCardSelected(CardController controller)
        {
            if (_selectedController == null)
            {
                _selectedController = controller;
                return;
            }
            
            if (controller == _selectedController)
            {
                _selectedController = null;
                return;
            }
            
            if (_selectedController.ID == controller.ID)
            {
                _selectedController = null;
                Matched.Invoke(controller.ID);
                return;
            }

            _selectedController.Deselect().Forget();
            controller.Deselect().Forget();
            _selectedController = null;
            Mismatched.Invoke();
        }
        
        private CardController CreateCardController(IReadOnlyCardEntity cardEntity)
        {
            var cardData = _levelData.Cards.FirstOrDefault(cardData => cardData.ID == cardEntity.ID);
            var cardView = _view.CreateCardView(cardData, _levelData.CardBack);
            var cardPresenter = new CardController(cardEntity.ID, cardView);
            cardPresenter.Deselect().Forget();
            cardPresenter.Clicked.AddListener(() => OnCardSelected(cardPresenter));
            return cardPresenter;
        }
        
        public async UniTask Shuffle()
        {
            int seed = Random.Range(int.MinValue, int.MaxValue);
            _cardControllers.Shuffle(seed);
            //_levelsService.ShuffleField(_levelEntity.LevelIndex, seed);

            for (var i = 0; i < _cardControllers.Count; i++)
            {
                _cardControllers[i].SetOrderIndex(i);
            }

            await UniTask.Delay(TimeSpan.FromSeconds(_view.GridMoveDuration));
        }

        public async UniTask ShowCardsFor(TimeSpan time)
        {
            await UniTask.WhenAll(_cardControllers.Select(cardController => cardController.Select()));
            await UniTask.Delay(time);
            await UniTask.WhenAll(_cardControllers.Select(cardController => cardController.Deselect()));
        }
        
        public void CompletePair(string id)
        {
            var presenters = _cardControllers.FindAll(p => p.ID == id);
            foreach (var cardController in presenters)
            {
                cardController.SetAsMatched();
                cardController.PlayMatchedAnimation().Forget();
            }
        }
    }
}