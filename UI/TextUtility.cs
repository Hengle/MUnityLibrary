using UnityEngine;

namespace MUnityLibrary.UI
{
    public static class TextUtility
    {
        /// <summary>
        /// テキストに色をつける
        /// </summary>
        /// <param name="text">色をつけるテキスト</param>
        /// <param name="color">色</param>
        /// <returns></returns>
        public static string PaintedColor(this string text, Color color)
        {
            return $"<color=#{ColorUtility.ToHtmlStringRGBA(color)}>{text}</color>";
        }
    }
}