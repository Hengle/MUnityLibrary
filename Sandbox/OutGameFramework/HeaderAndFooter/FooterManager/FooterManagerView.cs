using System.Collections;
using UnityEngine;

namespace MUnityLibrary.OutGameFramework.HeaderAndFooter.Sandbox
{
    public class FooterManagerView : HeaderAndFooteViewBase
    {
        [SerializeField] private GameObject _rootPanel;

        public override IEnumerator ShowEnumerator()
        {
            Debug.LogError("Show");
            _rootPanel.SetActive(true);
            yield break;
        }

        public override IEnumerator HideEnumerator()
        {
            Debug.LogError("Hide");
            _rootPanel.SetActive(false);
            yield break;
        }
    }
}