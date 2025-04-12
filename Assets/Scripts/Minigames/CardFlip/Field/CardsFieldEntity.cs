using System.Collections.Generic;
using Minigames.CardFlip.Card;
using Minigames.CardFlip.Levels;
using Tools.Runtime;

namespace Minigames.CardFlip.Field
{
    public interface IReadOnlyCardsFieldEntity
    {
        IReadOnlyList<IReadOnlyCardEntity> Cards { get; }
    }
    
    public class CardsFieldEntity : IReadOnlyCardsFieldEntity
    {
        private readonly List<CardEntity> _cards;
        
        public IReadOnlyList<IReadOnlyCardEntity> Cards => _cards.ConvertAll<IReadOnlyCardEntity>(c => c);
        
        
        public CardsFieldEntity(LevelData levelData)
        {
            _cards = new List<CardEntity>();
            foreach (var cardData in levelData.Cards)
            {
                var cardEntity1 = CreateCardEntity(cardData);
                var cardEntity2 = CreateCardEntity(cardData);
                
                _cards.Add(cardEntity1);
                _cards.Add(cardEntity2);
            }
        }

        private CardEntity CreateCardEntity(CardData data)
        {
            var entity = new CardEntity(data.ID);
            return entity;
        }

        public void Shuffle(int seed)
        {
            _cards.Shuffle(seed);
        }

        public void CompletePair(string id)
        {
            var pair = _cards.FindAll(c => c.ID == id);

            foreach (var cardEntity in pair)
            {
                cardEntity.IsMatched = true;
            }
        }
    }
}