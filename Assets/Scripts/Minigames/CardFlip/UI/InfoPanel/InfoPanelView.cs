using TMPro;
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
        
        public void SetMatchCount(int count, int maxCount)
        {
            _matchCountText.text = $"Matches: {count}/{maxCount}";
        }
        
        public void SetMismatchCount(int count, int maxCount)
        {
            _mismatchCountText.text = $"Mismatches: {count}/{maxCount}";
        }
    }
}