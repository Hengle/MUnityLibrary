namespace MUnityLibrary.Common
{
    /// <summary>
    /// Singleton クラス
    /// </summary>
    public class Singleton
    {
        /// <summary>
        /// インスタンス
        /// </summary>
        private static Singleton _instance;

        public static Singleton Instance => _instance ?? (_instance = new Singleton());
    }
}