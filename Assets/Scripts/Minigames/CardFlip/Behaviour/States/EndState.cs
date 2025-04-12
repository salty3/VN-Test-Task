using Minigames.CardFlip.UI.EndScreen;
using UnityEngine.Events;

namespace Minigames.CardFlip.Behaviour.States
{
    public class EndState : GameState
    {
        public UnityEvent ContinueClicked { get; } = new();
        
        private readonly EndScreenController _endScreenController;

        public EndState(EndScreenController endScreenController)
        {
            _endScreenController = endScreenController;
        }

        public override void Initialize()
        {
            _endScreenController.ContinueClicked.AddListener(OnContinueClicked);
            _endScreenController.Show();
        }
        
        public override void Dispose()
        {
            _endScreenController.ContinueClicked.RemoveListener(OnContinueClicked);
            _endScreenController.Hide();
        }
        
        private void OnContinueClicked()
        {
            ContinueClicked.Invoke();
        }
    }
}