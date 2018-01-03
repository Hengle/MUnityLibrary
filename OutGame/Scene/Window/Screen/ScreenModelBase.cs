using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MUnityLibrary.OutGame
{
    public class ScreenModelBase
    {
        public string ScreenName { get; private set; }

        public ScreenModelBase()
        {
        }

        public void SetScreenName(string screenName)
        {
            ScreenName = screenName;
        }
    }
}