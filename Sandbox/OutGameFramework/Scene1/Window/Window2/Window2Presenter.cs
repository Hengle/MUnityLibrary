using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MUnityLibrary.OutGameFramework.Sandbox
{
    public class Window2Presenter : WindowPresenterBase
    {
        [SerializeField] private Window2View _view;

        public override void Initialize()
        {
            _view.Initialize();
        }
    }
}