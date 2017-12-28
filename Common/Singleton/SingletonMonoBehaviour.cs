using UnityEngine;

namespace MUnityLibrary.Common
{
    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance => _instance ?? (_instance = (T) FindObjectOfType(typeof(T)));

        private static T _instance;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = GetComponent<T>();
            }
        }

        public virtual void Initialize(bool hasDontDestroyOnLoad)
        {
            SetDontDestroyOnLoad(hasDontDestroyOnLoad);
        }

        private void SetDontDestroyOnLoad(bool hasDontDestroyOnLoad)
        {
            if (!hasDontDestroyOnLoad)
            {
                return;
            }

            DontDestroyOnLoad(gameObject);
        }
    }
}