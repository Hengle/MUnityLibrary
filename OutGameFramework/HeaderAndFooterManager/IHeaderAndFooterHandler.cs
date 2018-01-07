using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MUnityLibrary.OutGameFramework.HeaderAndFooter
{
    public interface IHeaderAndFooterHandler
    {
        IEnumerator ShowEnumerator();
        IEnumerator HideEnumerator();
    }
}