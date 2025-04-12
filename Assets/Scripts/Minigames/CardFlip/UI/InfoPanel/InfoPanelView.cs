﻿using TMPro;
using Tools.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace Minigames.CardFlip.UI.InfoPanel
{
    public class InfoPanelView : UIMonoBehaviour
    {
        [SerializeField] private TMP_Text _matchCountText;
        [SerializeField] private TMP_Text _mismatchCountText;
        [SerializeField] private Button _shuffleButton;
        
        public Button ShuffleButton => _shuffleButton;
        
        public void SetMatchCount(int count)
        {
            _matchCountText.text = $"Matches: {count}";
        }
        
        public void SetMismatchCount(int count)
        {
            _mismatchCountText.text = $"Mismatches: {count}";
        }
    }
}