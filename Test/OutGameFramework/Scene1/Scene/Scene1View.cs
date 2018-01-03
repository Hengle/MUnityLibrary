using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MUnityLibrary.OutGame.Test
{
    public class Scene1View : MonoBehaviour
    {
        [SerializeField] private Button _window1Button;

        [SerializeField] private Button _window2Button;

        public Button.ButtonClickedEvent Window1ButtonClickedEvent => _window1Button.onClick;

        public Button.ButtonClickedEvent Window2ButtonClickedEvent => _window2Button.onClick;

        public void Initialize()
        {
        }
    }
}