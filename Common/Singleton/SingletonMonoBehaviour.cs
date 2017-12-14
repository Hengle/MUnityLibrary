using UnityEngine;

namespace MUnityLibrary.Common
{
    /// <inheritdoc />
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
            if (_instance == null)
            {
                _instance = GetComponent<T>();
            }
            //DontDestroyOnLoad(gameObject);
        }

        public void SetDontDestroyOnLoad(bool isActive)
        {
            if (!isActive) return;
            DontDestroyOnLoad(gameObject);
        }

        public static T Instance => _instance ?? (_instance = (T) FindObjectOfType(typeof(T)));
    }
}