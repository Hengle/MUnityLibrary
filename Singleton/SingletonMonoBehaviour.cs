using UnityEngine;

namespace Masa
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
                DestroyImmediate(this.gameObject);
                return;
            }
            _instance = GetComponent<T>();
            DontDestroyOnLoad(gameObject);
        }

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = (T)FindObjectOfType(typeof(T));

                    if (_instance == null)
                    {
                        Debug.LogError(typeof(T) + "is nothing");
                    }
                }

                return _instance;
            }
        }
    }
}
