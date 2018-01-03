using System.Collections;
using UnityEngine;

namespace MUnityLibrary.OutGame.Test
{
    public class Scene1ScreenBasePresenter : ScreenPresenterBase
    {
        [SerializeField] private Scene1ScreenBaseView _view;

        public override void Initialize()
        {
            _view.Initialize();
        }

        public override IEnumerator OnBeforeOpenScreenEnumerator()
        {
            yield break;
        }
    }
}