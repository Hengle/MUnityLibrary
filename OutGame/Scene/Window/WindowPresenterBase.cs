using System;
using System.Collections;
using MUnityLibrary.Utility;
using UnityEngine;

namespace MUnityLibrary.OutGame
{
    public abstract class WindowPresenterBase : MonoBehaviour
    {
        public event Action BeginLoadScreenAction;

        public event Action EndLoadScreenAction;

        public ScreenPresenterBase CurrentOpenScreenPresenter { get; private set; }

        public GameObject CurrentOpenScreenPrefab { get; private set; }

        //private readonly Stack<ScreenPresenterBase> _screenStack = new Stack<ScreenPresenterBase>();

        protected WindowModelBase Model;

        public string CurrentOpenWindowName => Model.WindowName;

        private string CurrentScreenPath =>
            CurrentOpenScreenPresenter != null ? CurrentOpenScreenPresenter.ScreenName : "";

        public virtual void Initialize()
        {
        }

        public virtual IEnumerator OnBeforOpenWindowEnumerator()
        {
            yield break;
        }

        public IEnumerator OnOpenWindowEnumerator(string screenPrefabPath)
        {
            BeginLoadScreenAction.Exec();

            // TODO:LoadAsync化したい
            //var screenPrefab = Resources.LoadAsync(ConvertEnumToScreenName(screen));
            //yield return screenPrefab.isDone;
            if (CurrentOpenScreenPrefab == null)
            {
                if (CurrentScreenPath != screenPrefabPath)
                {
                    var prefab = Resources.Load<GameObject>(screenPrefabPath);
                    CurrentOpenScreenPrefab = Instantiate(prefab);
                    CurrentOpenScreenPrefab.transform.SetParent(this.transform, false);
                    CurrentOpenScreenPresenter = CurrentOpenScreenPrefab.GetComponent<ScreenPresenterBase>();
                    CurrentOpenScreenPresenter.Initialize();
                }
            }

            yield return StartCoroutine(CurrentOpenScreenPresenter?.OnBeforeOpenScreenEnumerator());
            yield return StartCoroutine(CurrentOpenScreenPresenter?.OnOpenScreenEnumerator());
            EndLoadScreenAction.Exec();
        }

        public IEnumerator OnBeforeCloseWindowEnumerator()
        {
            yield break;
        }

        public IEnumerator OnCloseWindowEnumerator()
        {
            if (CurrentOpenScreenPresenter == null)
            {
                yield break;
            }

            yield return StartCoroutine(CurrentOpenScreenPresenter.OnBeforeCloseScreenEnumerator());
            yield return StartCoroutine(CurrentOpenScreenPresenter.OnCloseScreenEnumerator());
            DestroyUtility.SafeDestroy(CurrentOpenScreenPrefab);
        }

        public IEnumerator OnBeforeCloseScreenEnumerator()
        {
            yield return StartCoroutine(CurrentOpenScreenPresenter.OnBeforeCloseScreenEnumerator());
        }

        public IEnumerator OnCloseScreenEnumerator()
        {
            yield return StartCoroutine(CurrentOpenScreenPresenter.OnCloseScreenEnumerator());
        }
    }
}