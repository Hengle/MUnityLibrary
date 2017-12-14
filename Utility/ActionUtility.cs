using System;

namespace MUnityLibrary.Utility
{
    /// <summary>
    /// Action に関するユーティリティクラス
    /// </summary>
    public static class ActionUtility
    {
        /// <summary>
        /// Action を安全に実行する
        /// </summary>
        /// <param name="action">Action</param>
        public static void Exec(this Action action)
        {
            action?.Invoke();
        }

        /// <summary>
        /// Action<T> を安全に実行する
        /// </summary>
        /// <param name="action">Action.</param>
        /// <param name="param"></param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static void Exec<T>(this Action<T> action, T param)
        {
            action?.Invoke(param);
        }
    }
}