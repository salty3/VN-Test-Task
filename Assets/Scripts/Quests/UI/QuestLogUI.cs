using Naninovel.UI;
using TMPro;
using UnityEngine;

namespace Quests.UI
{
    public class QuestLogUI : CustomUI, IQuestLogUI
    {
        [SerializeField] private TMP_Text _questText;
        
        public void StartQuest(string text)
        {
            _questText.text = text;
        }

        public void UpdateQuest(string text)
        {
            _questText.text = text;
        }

        public void CompleteQuest(string text)
        {
            _questText.text = text;
        }
    }
}