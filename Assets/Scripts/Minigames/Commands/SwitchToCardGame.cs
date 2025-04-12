using Minigames.CardFlip;
using Naninovel;

namespace Game.Scripts.Commands
{
    [CommandAlias("cardGame")]
    public class SwitchToCardGame : Command
    {
        public override async UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            await Engine.GetService<ICardGameService>().PlayGame(asyncToken);
        }
    }
}