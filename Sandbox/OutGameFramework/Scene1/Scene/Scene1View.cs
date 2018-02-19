using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MUnityLibrary.OutGameFramework.Sandbox
{
    public class Scene1View : MonoBehaviour
    {
        [SerializeField] private Button _window1Button;

        [SerializeField] private Button _window2Button;

        [SerializeField] private Button _footerShowButton;

        [SerializeField] private Button _footerHideButton;

        [SerializeField] private Button _headerShowButton;

        [SerializeField] private Button _headerHideButton;

        public Button.ButtonClickedEvent Window1ButtonClickedEvent
        {
            get { return _window1Button.onClick; }
        }

        public Button.ButtonClickedEvent Window2ButtonClickedEvent
        {
            get { return _window2Button.onClick; }
        }

        public Button.ButtonClickedEvent FooterShowButtonClickedEvent
        {
            get { return _footerShowButton.onClick; }
        }

        public Button.ButtonClickedEvent FooterHideButtonClickedEvent
        {
            get { return _footerHideButton.onClick; }
        }

        public Button.ButtonClickedEvent HeaderShowButtonClickedEvent
        {
            get { return _headerShowButton.onClick; }
        }

        public Button.ButtonClickedEvent HeaderHideButtonClickedEvent
        {
            get { return _headerHideButton.onClick; }
        }

        public void Initialize()
        {
        }
    }
}