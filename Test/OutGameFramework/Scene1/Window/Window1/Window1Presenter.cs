using UnityEditor;
using UnityEngine;

namespace MUnityLibrary.OutGame.Test
{
    public class Window1Presenter : WindowPresenterBase
    {
        [SerializeField] private Window1View _view;

        public override void Initialize()
        {
            Model = new WindowModelBase(ResourcePathUtility.ConvertEnumToWindowPath(Scene1WindowType.Window1));
            _view.Initialize();
            SetEvent();
        }

        private void SetEvent()
        {
            _view.OnClickedMoveScreenAction += MoveScreen;
        }

        private static void MoveScreen(Scene1ScreenType type)
        {
            SceneLoader.Instance.LoadScreen(ResourcePathUtility.ConvertEnumToScreenPath(type));
        }
    }
}