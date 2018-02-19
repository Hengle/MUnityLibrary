using MUnityLibrary.Common;

namespace MUnityLibrary.OutGameFramework
{
    public class SceneLoader : SingletonMonoBehaviour<SceneLoader>
    {
        protected override void Initialize()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void LoadScene(string sceneName, string windowPath, string screenPath, object param = null)
        {
            SceneManagerPresenter.Instance.LoadScene(sceneName, windowPath, screenPath, param);
        }

        public void LoadWindow(string windowPath, string screenPath, object param = null)
        {
            SceneManagerPresenter.Instance.LoadWindow(windowPath, screenPath, param);
        }

        public void LoadScreen(string screenPath, object param = null)
        {
            SceneManagerPresenter.Instance.LoadScreen(screenPath, param);
        }
    }
}