using System;
using System.Collections;
using MUnityLibrary.Common;
using MUnityLibrary.Utility;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MUnityLibrary.OutGame
{
    public class SceneManagerPresenter : SingletonMonoBehaviour<SceneManagerPresenter>
    {
        private SceneManagerModel _model;

        public event Action BeginLoadScene;

        public event Action<object> EndLoadScene;

        private static ScenePresenterBase CurrentScene => GetCurrentScenePresenter();

        protected override bool HasDontDestroyOnLoad => true;

        protected override void Initialize()
        {
            _model = new SceneManagerModel();
            CurrentScene.Initialize();
        }

        private void Start()
        {
            // ScenePresenterBase の Initialize は Awake で呼ばれる。
            // 初期画面の Open を Awake で呼んでしまうと固まるので、Start で読む
            CurrentScene.InitializeOpen();
        }

        public void LoadScene(string sceneName, string windowName, string screenName, object param = null)
        {
            StartCoroutine(LoadSceneEnumerator(sceneName, windowName, screenName, param));
        }

        public void LoadWindow(string windowName, string screenName, object param = null)
        {
            StartCoroutine(LoadSceneEnumerator(CurrentScene.CurrentOpenSceneName, windowName, screenName, param));
        }

        public void LoadScreen(string screenName, object param = null)
        {
            StartCoroutine(LoadSceneEnumerator(CurrentScene.CurrentOpenSceneName, CurrentScene.CurrentOpenWindowName,
                screenName, param));
        }

        private IEnumerator LoadSceneEnumerator(string sceneName, string windowName, string screenName, object param)
        {
            BeginLoadScene.Exec();

            var loadScenePresenter = GetCurrentScenePresenter();

            if (_model.CurrentSceneName != sceneName)
            {
                yield return SceneManager.LoadSceneAsync(sceneName);
                Resources.UnloadUnusedAssets();
                GC.Collect();
                loadScenePresenter.Initialize();
            }

            if (_model.CurrentWindowPath != windowName)
            {
                yield return StartCoroutine(loadScenePresenter.OnCloseWindowEnumerator());
            }

            if (_model.CurrentScreenPath != screenName)
            {
                yield return StartCoroutine(loadScenePresenter.OnCloseScreenEnumerator());
            }

            yield return StartCoroutine(loadScenePresenter.OnOpenWindowEnumerator(windowName, screenName));
            _model.SetCurrentWindowName(windowName);
            _model.SetCurrentScreenName(screenName);

            EndLoadScene.Exec(param);
        }

        private static ScenePresenterBase GetCurrentScenePresenter()
        {
            return FindObjectOfType(typeof(ScenePresenterBase)) as ScenePresenterBase;
        }
    }
}