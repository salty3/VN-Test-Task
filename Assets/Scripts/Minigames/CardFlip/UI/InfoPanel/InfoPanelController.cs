using Tools.Runtime;
using UnityEngine;
using UnityEngine.Events;

namespace Minigames.CardFlip.UI.InfoPanel
{
    public class InfoPanelController : CachedMonoBehaviour
    {
        [SerializeField] private InfoPanelView _view;

        public UnityEvent ShuffleButtonClicked => _view.ShuffleButton.onClick;
        
        public void SetMatchCount(int count)
        {
            _view.SetMatchCount(count);
        }
        
        public void SetMismatchCount(int count)
        {
            _view.SetMismatchCount(count);
        }
    }
}