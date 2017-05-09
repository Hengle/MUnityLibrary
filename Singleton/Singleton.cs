namespace Masa
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

        public static Singleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                }

                return _instance;
            }
        }
    }
}
