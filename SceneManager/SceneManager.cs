using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Masa.Scene
{
    public class SceneManager : SingletonMonoBehaviour<SceneManager>
    {
        private string _currentSceneName;

        SceneBase _currentSceneBase;

        public IEnumerator ChangeSceneEnumerator(string sceneName)
        {
            _currentSceneBase.OnMoveOut();
            yield return UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
            _currentSceneBase = FindObjectOfType<SceneBase>();
            Debug.LogError(_currentSceneBase);
            _currentSceneBase.OnMoveIn();
        }
    }
}
