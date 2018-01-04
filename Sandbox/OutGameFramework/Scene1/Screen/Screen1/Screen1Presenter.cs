using System.Collections;
using System.Collections.Generic;
using MUnityLibrary.OutGameFramework;
using UnityEngine;

namespace MUnityLibrary.OutGameFramework.Sandbox
{
    public class Screen1Presenter : ScreenPresenterBase
    {
        [SerializeField] private Screen1View _view;

        public override void Initialize()
        {
            _view.Initialize();
        }

        public override IEnumerator OnBeforeOpenScreenEnumerator()
        {
            yield return new WaitForSeconds(2.0f);
            Debug.LogError("BeforeOpenScreen1");
        }
    }
}