using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MUnityLibrary.OutGame
{
    public static class ResourcePathUtility
    {
        private const string WindowResourcePath = "Window/";

        private const string ScreenResourcePath = "Screen/";

        public static string ConvertEnumToWindowPath<T>(T windowType) where T : struct
        {
            return WindowResourcePath + windowType;
        }

        public static string ConvertEnumToScreenPath<T>(T screenType) where T : struct
        {
            return ScreenResourcePath + screenType;
        }
    }
}