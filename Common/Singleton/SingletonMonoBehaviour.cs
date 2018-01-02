using UnityEngine;

namespace MUnityLibrary.Common
{
    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance => _instance ?? (_instance = (T) FindObjectOfType(typeof(T)));

        private static T _instance;

        protected virtual bool HasDontDestroyOnLoad => false;

        private void Awake()
        {
            if (_instance != null)
            {
                return;
            }
            _instance = GetComponent<T>();
            SetDontDestroyOnLoad();
            Initialize();
        }

        protected abstract void Initialize();

        private void SetDontDestroyOnLoad()
        {
            if (!HasDontDestroyOnLoad)
            {
                return;
            }

            DontDestroyOnLoad(gameObject);
        }
    }
}