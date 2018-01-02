using UnityEngine.SceneManagement;

namespace MUnityLibrary.OutGame
{
    public class SceneManagerModel
    {
        public string CurrentSceneName => SceneManager.GetActiveScene().name;

        public string CurrentWindowPath { get; private set; }

        public string CurrentScreenPath { get; private set; }

        public SceneManagerModel()
        {
        }

        public void SetCurrentWindowName(string windowPath)
        {
            CurrentWindowPath = windowPath;
        }

        public void SetCurrentScreenName(string screenName)
        {
            CurrentScreenPath = screenName;
        }
    }
}