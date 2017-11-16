using System;

namespace MUnityLibrary.Utility
{
    /// <summary>
    /// System の Utility クラス
    /// </summary>
    public static class SystemUtility
    {
        /// <summary>
        /// Callback 関数を実行する
        /// </summary>
        public static void ExecCallback(Action callback)
        {
            if (callback != null)
            {
                callback();
            }
        }
    }
}

