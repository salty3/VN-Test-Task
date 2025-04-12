using System.Collections.Generic;
using Minigames.CardFlip.Card;
using UnityEngine;

namespace Minigames.CardFlip.Levels
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "MiniGames/LevelData")]
    public class LevelData : ScriptableObject
    {
        private const int MAX_PAIRS = 12;
        [field: SerializeField] public Sprite LevelPreviewIcon { get; private set; }
        [field: SerializeField] public Sprite CardBack { get; private set; }
        [field: SerializeField] public Sprite LevelBackground { get; private set; }
        [field: SerializeField] public int MaxMismatchCount { get; private set; } = 10;
        
        //Here should be some validation for max amount of pairs or level layering logic
        [SerializeField] private CardData[] _cards = new CardData[MAX_PAIRS];
        
        public IEnumerable<CardData> Cards => _cards;
    }
}