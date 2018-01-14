using System;
using System.Collections;
// using DG.Tweening;
using MUnityLibrary.Common;
using MUnityLibrary.Utility;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MUnityLibrary.OutGameFramework
{
    public class SceneManagerPresenter : SingletonMonoBehaviour<SceneManagerPresenter>
    {
        private SceneManagerModel _model;

        public event Action BeginLoadSceneAction;

        public event Action<object> EndLoadSceneAction;

        private static ScenePresenterBase CurrentScene => GetCurrentScene();

        protected override bool HasDontDestroyOnLoad => true;

        protected override void Initialize()
        {
            // DOTween.Init();
            _model = new SceneManagerModel();
            CurrentScene.Initialize();
        }

        private void Start()
        {
            // ScenePresenterBase の Initialize は Awake で呼ばれる。
            // 初期画面の Open を Awake で呼んでしまうと固まるので、Start で読む
            CurrentScene.InitializeOpen();
        }

        public void LoadScene(string loadSceneName, string loadWindowPath, string loadScreenPath, object param = null)
        {
            StartCoroutine(LoadSceneEnumerator(loadSceneName, loadWindowPath, loadScreenPath, param));
        }

        public void LoadWindow(string loadWindowPath, string loadScreenPath, object param = null)
        {
            StartCoroutine(
                LoadSceneEnumerator(CurrentScene.CurrentOpenSceneName, loadWindowPath, loadScreenPath, param));
        }

        public void LoadScreen(string loadScreenPath, object param = null)
        {
            StartCoroutine(LoadSceneEnumerator(CurrentScene.CurrentOpenSceneName, CurrentScene.CurrentOpenWindowPath,
                loadScreenPath, param));
        }

        private bool _isLoading = false;

        private IEnumerator LoadSceneEnumerator(string loadSceneName, string loadWindowPath, string loadScreenPath,
            object param)
        {
            if (_isLoading)
            {
                yield break;
            }

            BeginLoadSceneAction.Exec();
            _isLoading = true;

            ScenePresenterBase loadScenePresenter = GetCurrentScene();

            if (_model.CurrentSceneName != loadSceneName)
            {
                yield return SceneManager.LoadSceneAsync(loadSceneName);
                Resources.UnloadUnusedAssets();
                GC.Collect();
                loadScenePresenter = GetCurrentScene();
                loadScenePresenter.Initialize();
            }

            if (_model.CurrentWindowPath != loadWindowPath)
            {
                yield return StartCoroutine(loadScenePresenter.OnCloseWindowEnumerator());
            }

            if (_model.CurrentScreenPath != loadScreenPath)
            {
                yield return StartCoroutine(loadScenePresenter.OnCloseScreenEnumerator());
            }

            yield return StartCoroutine(loadScenePresenter.OnOpenWindowEnumerator(loadWindowPath, loadScreenPath));
            _model.SetCurrentWindowName(loadWindowPath);
            _model.SetCurrentScreenName(loadScreenPath);

            EndLoadSceneAction.Exec(param);
            _isLoading = false;
        }

        private static ScenePresenterBase GetCurrentScene()
        {
            return FindObjectOfType(typeof(ScenePresenterBase)) as ScenePresenterBase;
        }
    }
}