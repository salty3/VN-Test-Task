using Minigames.CardFlip.Levels;
using Naninovel;
using Tools.SceneManagement.Runtime;

namespace Minigames.CardFlip
{
    [EditInProjectSettings]
    public class CardGameConfiguration : Configuration
    {
        public SceneReference GameScene;
        public LevelData[] Levels;
    }
}