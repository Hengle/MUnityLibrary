using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MUnityLibrary.Sound
{
    public class BGMManagerTest : MonoBehaviour
    {
        [SerializeField] private Button _seButton;

        [SerializeField] private Button _bgm1Button;

        [SerializeField] private Button _bgm2Button;

        [SerializeField] private AudioClip _se;

        [SerializeField] private AudioClip _bgm1;

        [SerializeField] private AudioClip _bgm2;

        private void Start()
        {
            _bgm1Button.onClick.AddListener(PlayBGM1);
            _bgm2Button.onClick.AddListener(PlayBGM2);
        }

        private void PlayBGM1()
        {
            SoundManager.Instance.PlayBgm(_bgm1);
        }

        private void PlayBGM2()
        {
            SoundManager.Instance.PlayBgm(_bgm2);
        }
    }
}