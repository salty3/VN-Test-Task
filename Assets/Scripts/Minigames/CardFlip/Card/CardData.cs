using UnityEngine;

namespace Minigames.CardFlip.Card
{
    [CreateAssetMenu(fileName = "CardData", menuName = "Game/CardData")]
    public class CardData : ScriptableObject
    {
        [field: SerializeField] public string ID { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        
    }
}