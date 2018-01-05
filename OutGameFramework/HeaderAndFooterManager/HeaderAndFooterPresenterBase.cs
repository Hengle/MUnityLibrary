using System.Collections;
using MUnityLibrary.Common;
using UnityEngine;

namespace MUnityLibrary.OutGameFramework.HeaderAndFooter
{
    public abstract class HeaderAndFooterManagerPresenterBase<T> :
        SingletonMonoBehaviour<HeaderAndFooterManagerPresenterBase<T>>,
        IHeaderAndFooterHandler
    {
        [SerializeField] protected HeaderAndFooteViewBase View;

        public virtual IEnumerator ShowEnumerator()
        {
            yield return StartCoroutine(View.ShowEnumerator());
        }

        public virtual IEnumerator HideEnumerator()
        {
            yield return StartCoroutine(View.HideEnumerator());
        }
    }
}