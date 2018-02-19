using UnityEngine;
using System.Collections;
using System;
using MUnityLibrary.Common;
using MUnityLibrary.Utility;

namespace MUnityLibrary.Sound
{
    [RequireComponent(typeof(AudioListener))]
    public class SoundManager : SingletonMonoBehaviour<SoundManager>
    {
        /// <summary>
        /// BGM の AudioSource
        /// </summary>
        [SerializeField] private AudioSource _bgmAudioSource;

        /// <summary>
        /// SE の AudioSource
        /// </summary>
        [SerializeField] private AudioSource _seAudioSource;

        /// <summary>
        /// 現在再生している BGM の再生位置
        /// </summary>
        public float PlayBgmCurrentTimePosition
        {
            get { return _bgmAudioSource.time; }
        }

        protected override void Initialize()
        {
            DontDestroyOnLoad(gameObject);
        }

        #region BGM

        /// <summary>
        /// time を直接セットする
        /// </summary>
        public void SetBgmTimePosition(float timePosition)
        {
            _bgmAudioSource.time = timePosition;
        }

        /// <summary>
        /// Time を取得する
        /// </summary>
        public float GetBgmTimePosition()
        {
            return _bgmAudioSource.time;
        }

        /// <summary>
        /// BGM を流す
        /// </summary>
        public void PlayBgm(AudioClip audioClip, float playPosition = 0.0f, float fadeOutTime = 1.0f,
            float fadeInTime = 0.0f, Action onComplete = null)
        {
            StartCoroutine(ChangeBgmEnumrator(audioClip, playPosition, fadeOutTime, fadeInTime, onComplete));
        }

        /// <summary>
        /// BGM を止める
        /// </summary>
        public void StopBgm(float fadeOutTime = 1.0f, Action onComplete = null)
        {
            StartCoroutine(ChangeBgmEnumrator(null, 0, fadeOutTime, 0, onComplete));
        }

        /// <summary>
        /// BGM切替時の処理
        /// </summary>        
        private IEnumerator ChangeBgmEnumrator(AudioClip nextBgmClip, float playPostion, float fadeOutTime,
            float fadeInTime, Action onComplete)
        {
            // 同じ BGM が指定された場合は切り替えしないようにする
            if (_bgmAudioSource.clip == nextBgmClip)
            {
                yield break;
            }

            // なにかしらの BGM が鳴っていて、さらに FadeOutTime が指定されていたら、その BGM をフェードアウトさせる
            if (_bgmAudioSource.clip != null && fadeOutTime != 0)
            {
                for (float f = 1; f > 0; f -= Time.deltaTime / fadeOutTime)
                {
                    _bgmAudioSource.volume = f;
                    yield return null;
                }
            }

            // Volume に小数点以下の微妙な値が残るので 0 を入れてきれいな値にしておく
            _bgmAudioSource.volume = 0;
            _bgmAudioSource.clip = null;

            // 指定された BGM があるなら、その BGM をフェードインで鳴らす
            if (nextBgmClip == null)
            {
                yield break;
            }

            _bgmAudioSource.clip = nextBgmClip;
            _bgmAudioSource.time = playPostion;

            _bgmAudioSource.Play();

            // FadeInTime が指定されていればフェードインさせる
            if (fadeInTime != 0)
            {
                for (float f = 0; f < 1; f += Time.deltaTime / fadeInTime)
                {
                    _bgmAudioSource.volume = f;
                    yield return null;
                }
            }

            _bgmAudioSource.volume = 1;
            onComplete.Exec();
        }

        #endregion

        #region SE

        /// <summary>
        /// SE を流す
        /// </summary>
        public void PlayOneShotSe(AudioClip audioClip)
        {
            _seAudioSource.PlayOneShot(audioClip);
        }

        #endregion
    }
}