using Tools.Runtime.StateBehaviour;

namespace Minigames.CardFlip.Behaviour
{
    public class GameplayLoopStateManager : StateManager<GameState>
    {
        public GameplayLoopStateManager(params GameState[] states) : base(states)
        {
            foreach (var state in states)
            {
                state.SetStateManager(this);
            }
        }
    }
}