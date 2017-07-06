using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Masa.Sound;

public class SoundManagerTest : MonoBehaviour
{
    [SerializeField]
    private Button SEButton;

    [SerializeField]
    private Button BGM1Button;

    [SerializeField]
    private Button BGM2Button;

    [SerializeField]
    private AudioClip _se;

    [SerializeField]
    private AudioClip _bgm1;

    [SerializeField]
    private AudioClip _bgm2;

    private void Start()
    {
        SEButton.onClick.AddListener(PlaySE);
    }

    private void PlaySE()
    {
        SoundManager.Instance.PlayOneShotSE(_se);
    }

    private void PlayBGM1()
    {
        SoundManager.Instance.PlayBGM(_bgm1);
    }

    private void PlayBGM2()
    {
        SoundManager.Instance.PlayBGM(_bgm2);
    }
}
