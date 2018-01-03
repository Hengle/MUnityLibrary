using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MUnityLibrary.Sound;

public class SoundManagerTest : MonoBehaviour
{
    [SerializeField] private Button _seButton;

    [SerializeField] private Button _bgm1Button;

    [SerializeField] private Button _bgm2Button;

    [SerializeField] private AudioClip _se;

    [SerializeField] private AudioClip _bgm1;

    [SerializeField] private AudioClip _bgm2;

    private void Start()
    {
        SetEvent();
    }

    private void SetEvent()
    {
        _seButton.onClick.AddListener(PlaySe);
    }

    private void PlaySe()
    {
        SoundManager.Instance.PlayOneShotSe(_se);
    }

    private void PlayBgm1()
    {
        SoundManager.Instance.PlayBgm(_bgm1);
    }

    private void PlayBgm2()
    {
        SoundManager.Instance.PlayBgm(_bgm2);
    }
}