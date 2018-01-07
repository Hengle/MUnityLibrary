using System.Collections;
using System.Configuration;
using MUnityLibrary.OutGameFramework.HeaderAndFooter.Sandbox;
using UnityEngine;

namespace MUnityLibrary.OutGameFramework.Sandbox
{
    public class Scene1Presenter : ScenePresenterBase
    {
        private const string SceneName = "Scene1";

        [SerializeField] private Scene1View _view;

        public override void Initialize()
        {
            Model.SetSceneName(SceneName);
            _view.Initialize();
            SetEvent();
        }

        public override void InitializeOpen()
        {
            OpenWindow(Scene1WindowType.Window1, Scene1ScreenType.Screen1);
        }

        private void SetEvent()
        {
            _view.Window1ButtonClickedEvent.AddListener(() =>
                OpenWindow(Scene1WindowType.Window1, Scene1ScreenType.Screen1));

            _view.Window2ButtonClickedEvent.AddListener(() =>
                OpenWindow(Scene1WindowType.Window2, Scene1ScreenType.Screen1));

            _view.FooterShowButtonClickedEvent.AddListener(() =>
            {
                StartCoroutine(FooterManagerPresenter.Instance.ShowEnumerator());
            });

            _view.FooterHideButtonClickedEvent.AddListener(() =>
            {
                StartCoroutine(FooterManagerPresenter.Instance.HideEnumerator());
            });

            _view.HeaderShowButtonClickedEvent.AddListener(() =>
            {
                StartCoroutine(HeaderManagerPresenter.Instance.ShowEnumerator());
            });

            _view.HeaderHideButtonClickedEvent.AddListener(() =>
            {
                StartCoroutine(HeaderManagerPresenter.Instance.HideEnumerator());
            });
        }

        private static void OpenWindow(Scene1WindowType windowType, Scene1ScreenType screenType)
        {
            string windowPath = ResourcePathUtility.ConvertEnumToWindowPath(windowType);
            string screenPath = ResourcePathUtility.ConvertEnumToScreenPath(screenType);
            SceneLoader.Instance.LoadWindow(windowPath, screenPath);
        }
    }
}