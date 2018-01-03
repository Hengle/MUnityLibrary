using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MUnityLibrary.OutGame.Test
{
    public class Screen2Presenter : ScreenPresenterBase
    {
        [SerializeField] private Screen2View _view;

        public override void Initialize()
        {
            _view.Initialize();
        }
    }
}