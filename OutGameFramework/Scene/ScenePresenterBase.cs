using System;
using System.Collections;
using MUnityLibrary.Utility;
using UnityEngine;

namespace MUnityLibrary.OutGameFramework
{
    public abstract class
        ScenePresenterBase : MonoBehaviour
    {
        protected readonly SceneModelBase Model = new SceneModelBase();

        public event Action BeginLoadWindowAction;

        public event Action EndLoadWindowAction;

        public string CurrentOpenSceneName => Model.SceneName;

        public string CurrentOpenWindowPath =>
            _currentOpenWindow != null ? _currentOpenWindow.CurrentOpenWindowPath : "";

        private WindowPresenterBase _currentOpenWindow;

        private GameObject _currentWindowGameObject;

        public abstract void Initialize();

        public abstract void InitializeOpen();

        public IEnumerator OnOpenWindowEnumerator(string windowPrefabPath, string screenPrefabPath)
        {
            BeginLoadWindowAction.Exec();

            if (_currentWindowGameObject == null)
            {
                if (CurrentOpenWindowPath != windowPrefabPath)
                {
                    // TODO:LoadAsync化したい
                    // var prefab = Resources.LoadAsync<GameObject>(prefabName);
                    // yield return new WaitUntil(() => prefab.isDone);
                    var prefab = Resources.Load<GameObject>(windowPrefabPath);
                    _currentWindowGameObject = Instantiate(prefab);
                    _currentWindowGameObject.transform.SetParent(this.transform, false);
                    _currentOpenWindow = _currentWindowGameObject.GetComponent<WindowPresenterBase>();
                    _currentOpenWindow.Initialize();
                }
            }

            yield return StartCoroutine(_currentOpenWindow.OnBeforeOpenWindowEnumerator());
            yield return StartCoroutine(_currentOpenWindow.OnOpenWindowEnumerator(screenPrefabPath));

            EndLoadWindowAction.Exec();
        }

        public IEnumerator OnCloseWindowEnumerator()
        {
            if (_currentOpenWindow == null)
            {
                yield break;
            }

            yield return StartCoroutine(_currentOpenWindow.OnBeforeCloseWindowEnumerator());
            yield return StartCoroutine(_currentOpenWindow.OnCloseWindowEnumerator());
            DestroyUtility.SafeDestroy(_currentWindowGameObject);
        }

        public IEnumerator OnCloseScreenEnumerator()
        {
            if (_currentOpenWindow == null)
            {
                yield break;
            }

            if (_currentOpenWindow.CurrentOpenScreenPresenter == null)
            {
                yield break;
            }

            yield return StartCoroutine(_currentOpenWindow.OnBeforeCloseScreenEnumerator());
            yield return StartCoroutine(_currentOpenWindow.OnCloseScreenEnumerator());
            DestroyUtility.SafeDestroy(_currentOpenWindow.CurrentOpenScreenPrefab);
        }
    }
}