using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace MUnityLibrary.OutGameFramework.HeaderAndFooter.Sandbox
{
    public class HeaderManagerView : HeaderAndFooteViewBase
    {
        [SerializeField] private RectTransform _panelRectTransform;

        public override IEnumerator ShowEnumerator()
        {
            var showTweener = _panelRectTransform.DOAnchorPosY(0, 0.5f, true);
            DOTween.Sequence().Append(showTweener).Play().WaitForCompletion();
            yield break;
        }

        public override IEnumerator HideEnumerator()
        {
            var hideTweener = _panelRectTransform.DOAnchorPosY(200, 0.5f, true);
            DOTween.Sequence().Append(hideTweener).Play().WaitForCompletion();
            yield break;
        }
    }
}