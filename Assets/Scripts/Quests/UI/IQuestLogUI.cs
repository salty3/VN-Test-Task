using Naninovel.UI;

namespace Quests.UI
{
    public interface IQuestLogUI : IManagedUI
    {
        void StartQuest(string text);
        void UpdateQuest(string text);
        void CompleteQuest(string text);
    }
}