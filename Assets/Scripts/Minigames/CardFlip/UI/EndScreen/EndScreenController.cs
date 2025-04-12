using Tools.Runtime;
using UnityEngine;
using UnityEngine.Events;

namespace Minigames.CardFlip.UI.EndScreen
{
    public class EndScreenController : CachedMonoBehaviour
    {
        [SerializeField] private EndScreenView _view;
        
        public UnityEvent ContinueClicked => _view.ContinueClicked;

        private void Awake()
        {
            Hide();
        }
        
        public void Show()
        {
            _view.Show();
        }
        
        public void Hide()
        {
            _view.Hide();
        }
    }
}