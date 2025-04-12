using Naninovel;

namespace Minigames.CardFlip
{
    public interface ICardGameService : IEngineService
    {
        public UniTask PlayGame(AsyncToken asyncToken = default);
    }
}