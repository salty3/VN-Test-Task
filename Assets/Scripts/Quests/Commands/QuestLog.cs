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
        
        [RequiredParameter]
        public StringParameter Text;
        
        public override async UniTask ExecuteAsync(AsyncToken asyncToken = default)
        {
            if (!Enum.TryParse(LogType, out QuestLogType logType))
            {
                throw new FormatException("Invalid quest log type");
            }
            
            var questLogUi = Engine.GetService<IUIManager>().GetUI<IQuestLogUI>();

            
            //TODO: await for animations
            switch (logType)
            {
                case QuestLogType.Start:
                    questLogUi.Show();
                    questLogUi.StartQuest(Text);
                    break;
                case QuestLogType.Update:
                    questLogUi.UpdateQuest(Text);
                    break;
                case QuestLogType.Complete:
                    questLogUi.CompleteQuest(Text);
                    await UniTask.Delay(TimeSpan.FromSeconds(1));
                    questLogUi.Hide();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}