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
        public static void ActionSafeExec(Action action)
        {
            if (action != null)
            {
                action();
            }
        }

        /// <summary>
        /// Action<T> を安全に実行する
        /// </summary>
        /// <param name="action">Action.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        public static void ActionSafeExec<T>(Action<T> action, T param)
        {
            if (action != null)
            {
                action(param);
            }
        }
    }
}
