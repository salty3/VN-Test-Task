using System;
using Naninovel;
using Naninovel.UI;
using TMPro;
using UnityEngine;

namespace Quests.UI
{
    public class QuestLogUI : CustomUI, IQuestLogUI
    {
        [SerializeField] private RevealableText _questText;

        private TextRevealer _textRevealer;

        protected override void Awake()
        {
            base.Awake();
            _textRevealer = new TextRevealer(_questText);
        }

        public async UniTask StartQuest(string text, AsyncToken token = default)
        {
            _questText.RevealProgress = 0;
            _questText.Text = text;
            await _textRevealer.RevealAsync(0.03f, token);
        }

        public async UniTask UpdateQuest(string text, AsyncToken token = default)
        {
            _questText.RevealProgress = 0;
            _questText.Text = text;
            await _textRevealer.RevealAsync(0.03f, token);
        }

        public void CompleteQuest()
        {
            _questText.Text = string.Empty;
        }
    }
}