using Tools.Runtime;
using UnityEngine;
using UnityEngine.Events;

namespace Minigames.CardFlip.UI.InfoPanel
{
    public class InfoPanelController : CachedMonoBehaviour
    {
        [SerializeField] private InfoPanelView _view;

        public UnityEvent ShuffleButtonClicked => _view.ShuffleButton.onClick;
        
        public void SetMatchCount(int count, int maxCount)
        {
            _view.SetMatchCount(count, maxCount);
        }
        
        public void SetMismatchCount(int count, int maxCount)
        {
            _view.SetMismatchCount(count, maxCount);
        }
    }
}