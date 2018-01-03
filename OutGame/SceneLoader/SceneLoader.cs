using MUnityLibrary.Common;

namespace MUnityLibrary.OutGame
{
    public class SceneLoader : SingletonMonoBehaviour<SceneLoader>
    {
        protected override bool HasDontDestroyOnLoad => true;

        protected override void Initialize()
        {
        }

        public void LoadScene(string sceneName, string windowName, string screenName, object param = null)
        {
            SceneManagerPresenter.Instance.LoadScene(sceneName, windowName, screenName, param);
        }

        public void LoadWindow(string windowName, string screenName, object param = null)
        {
            SceneManagerPresenter.Instance.LoadWindow(windowName, screenName, param);
        }

        public void LoadScreen(string screenName, object param = null)
        {
            SceneManagerPresenter.Instance.LoadScreen(screenName, param);
        }
    }
}