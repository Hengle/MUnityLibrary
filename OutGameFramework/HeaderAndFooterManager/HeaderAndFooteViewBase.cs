using System.Collections;
using UnityEngine;

namespace MUnityLibrary.OutGameFramework.HeaderAndFooter
{
    public abstract class HeaderAndFooteViewBase : MonoBehaviour, IHeaderAndFooterHandler
    {
        public abstract IEnumerator ShowEnumerator();

        public abstract IEnumerator HideEnumerator();
    }
}