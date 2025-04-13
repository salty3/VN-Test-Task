using System;
using Naninovel;
using Quests.UI;

namespace Quests.Commands
{
    [CommandAlias("questLog")]
    public class QuestLog : Command
    {
        [RequiredParameter]
        [ConstantContext(typeof(QuestLogType))]
        public StringParameter LogType;
        
        public StringParameter Text;
        
        public override async UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            if (!Enum.TryParse(LogType, out QuestLogType logType))
            {
                throw new FormatException("Invalid quest log type");
            }
            
            var questLogUi = Engine.GetService<IUIManager>().GetUI<IQuestLogUI>();
            
            switch (logType)
            {
                case QuestLogType.Start:
                    await questLogUi.ChangeVisibilityAsync(true, 0.3f, asyncToken);
                    await questLogUi.StartQuest(Text);
                    break;
                case QuestLogType.Update:
                    await questLogUi.UpdateQuest(Text);
                    break;
                case QuestLogType.Complete:
                    questLogUi.CompleteQuest();
                    await questLogUi.ChangeVisibilityAsync(false, 0.3f, asyncToken);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}