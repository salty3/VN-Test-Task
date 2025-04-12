using Tools.Runtime.StateBehaviour;

namespace Minigames.CardFlip.Behaviour
{
    public abstract class GameState : IState
    {
        protected GameplayLoopStateManager StateManager { get; private set; }
        
        public void SetStateManager(GameplayLoopStateManager stateManager)
        {
            StateManager = stateManager;
        }
        
        public abstract void Initialize();
        public abstract void Dispose();
    }
}