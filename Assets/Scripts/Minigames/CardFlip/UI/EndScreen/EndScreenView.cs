using Tools.Runtime;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Minigames.CardFlip.UI.EndScreen
{
    public class EndScreenView : UIMonoBehaviour
    {
        [SerializeField] private Button _continueButton;

        public UnityEvent ContinueClicked => _continueButton.onClick;
        
        public void Show()
        {
            GameObject.SetActive(true);
        }
        
        public void Hide()
        {
            if (this == null)
            {
                return;
            }
            
            GameObject.SetActive(false);
        }
    }
}