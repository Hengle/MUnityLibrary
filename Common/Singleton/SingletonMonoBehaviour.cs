using UnityEngine;

namespace MUnityLibrary.Common
{
    /// <summary>
    /// MonoBehaviour の Singleton クラス
    /// </summary>
    public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        /// <summary>
        /// インスタンス
        /// </summary>
        private static T _instance;

        private void Awake()
        {
            if (_instance != null)
            {
                // なんか Unity がおかしい気がするが、とりあえず対処
                // DestroyImmediate (this.gameObject);
                return;
            }
            _instance = GetComponent<T>();
            //DontDestroyOnLoad(gameObject);
        }

        public void SetDontDestroyOnLoad(bool isActive)
        {
            if (isActive)
            {
                DontDestroyOnLoad(gameObject);
            };
        }

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = (T)FindObjectOfType(typeof(T));
                }

                return _instance;
            }
        }
    }
}