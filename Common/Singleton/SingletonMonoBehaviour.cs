using UnityEngine;

namespace MUnityLibrary.Common
{
    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance
        {
            get { return _instance ?? (_instance = (T) FindObjectOfType(typeof(T))); }
        }

        private static T _instance;

        private void Awake()
        {
            if (_instance != null)
            {
                return;
            }

            _instance = GetComponent<T>();
        }

        protected abstract void Initialize();
    }
}