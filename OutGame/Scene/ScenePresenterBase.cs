using System;
using System.Collections;
using MUnityLibrary.Utility;
using UnityEngine;

namespace MUnityLibrary.OutGame
{
    public abstract class
        ScenePresenterBase : MonoBehaviour
    {
        protected readonly SceneModelBase Model = new SceneModelBase();

        public event Action BeginLoadWindowAction;

        public event Action EndLoadWindowAction;

        private WindowPresenterBase _currentOpenWindow;

        private GameObject _currentWindowPrefab;

        public string CurrentOpenSceneName => Model.SceneName;

        public string CurrentOpenWindowName =>
            _currentOpenWindow != null ? _currentOpenWindow.CurrentOpenWindowName : "";

        public abstract void Initialize();

        public abstract void InitializeOpen();

        public IEnumerator OnOpenWindowEnumerator(string windowPrefabPath, string screenPrefabPath)
        {
            BeginLoadWindowAction.Exec();

            if (_currentWindowPrefab == null)
            {
                if (CurrentOpenWindowName != windowPrefabPath)
                {
                    // TODO:LoadAsync化したい
                    // var prefab = Resources.LoadAsync<GameObject>(prefabName);
                    // yield return new WaitUntil(() => prefab.isDone);
                    var prefab = Resources.Load<GameObject>(windowPrefabPath);
                    _currentWindowPrefab = Instantiate(prefab);
                    _currentWindowPrefab.transform.SetParent(this.transform, false);
                    _currentOpenWindow = _currentWindowPrefab.GetComponent<WindowPresenterBase>();
                    _currentOpenWindow.Initialize();
                }
            }

            yield return StartCoroutine(_currentOpenWindow?.OnBeforOpenWindowEnumerator());
            yield return StartCoroutine(_currentOpenWindow?.OnOpenWindowEnumerator(screenPrefabPath));

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
            DestroyUtility.SafeDestroy(_currentWindowPrefab);
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