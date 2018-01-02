using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MUnityLibrary.OutGame.Test
{
    public class Screen3Presenter : ScreenPresenterBase
    {
        [SerializeField] private Screen3View _view;

        public override void Initialize()
        {
            _view.Initialize();
        }
    }
}