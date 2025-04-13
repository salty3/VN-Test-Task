using Naninovel;
using Naninovel.UI;

namespace Quests.UI
{
    public interface IQuestLogUI : IManagedUI
    {
        UniTask StartQuest(string text, AsyncToken token = default);
        UniTask UpdateQuest(string text, AsyncToken token = default);
        void CompleteQuest();
    }
}