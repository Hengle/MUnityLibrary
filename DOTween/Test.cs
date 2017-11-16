using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Test : MonoBehaviour
{
    int _beginIntValue = 1130;
    int _addValue = 50;
    [SerializeField] private Transform _scale;
    [SerializeField] private Text _text;

    void Start()
    {
        DOTween.Init();

        int value = _beginIntValue;

        DOTween.To(() => value,
        x =>
        {
            value = x;
            _text.text = value.ToString();
            float xScale = ((float)value % 100) / 100;
            _scale.localScale = new Vector2(xScale, 1);
        },
        _beginIntValue + _addValue,
        2.0f);
    }
}
