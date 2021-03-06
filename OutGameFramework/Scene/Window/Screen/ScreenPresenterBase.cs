﻿using System.Collections;
using UnityEngine;

namespace MUnityLibrary.OutGameFramework
{
    public abstract class ScreenPresenterBase : MonoBehaviour
    {
        private readonly ScreenModelBase _model = new ScreenModelBase();

        public string ScreenName
        {
            get { return _model.ScreenName; }
        }

        public virtual void Initialize()
        {
        }

        public virtual IEnumerator OnBeforeOpenScreenEnumerator()
        {
            yield break;
        }

        public virtual IEnumerator OnOpenScreenEnumerator()
        {
            yield break;
        }

        public virtual IEnumerator OnBeforeCloseScreenEnumerator()
        {
            yield break;
        }

        public virtual IEnumerator OnCloseScreenEnumerator()
        {
            yield break;
        }
    }
}