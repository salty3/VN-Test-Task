namespace Minigames.CardFlip.Card
{
    public interface IReadOnlyCardEntity
    {
        string ID { get; }
        bool IsMatched { get; }
    }

    public class CardEntity : IReadOnlyCardEntity
    {
        public string ID { get; }
        public bool IsMatched { get; set; }

        public CardEntity(string id)
        {
            ID = id;
        }
    }
}