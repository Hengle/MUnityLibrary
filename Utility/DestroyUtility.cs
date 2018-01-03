using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MUnityLibrary.Utility
{
    public static class DestroyUtility
    {
        public static void SafeDestroy(GameObject targetGameObject)
        {
            Object.DestroyImmediate(targetGameObject);
            targetGameObject = null;
        }
    }
}