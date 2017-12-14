using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Test : MonoBehaviour
{
    private const int BeginIntValue = 1130;
    private const int AddValue = 50;
    [SerializeField] private Transform _scale;
    [SerializeField] private Text _text;

    private void Start()
    {
        DOTween.Init();

        int value = BeginIntValue;

        DOTween.To(() => value,
            x =>
            {
                value = x;
                _text.text = value.ToString();
                float xScale = ((float) value % 100) / 100;
                _scale.localScale = new Vector2(xScale, 1);
            },
            BeginIntValue + AddValue,
            2.0f);
    }
}