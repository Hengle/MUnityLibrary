using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Masa.Scene.Test
{
    public class LoadScene : MonoBehaviour
    {
        public void Load()
        {
            StartCoroutine(SceneManager.Instance.ChangeSceneEnumerator("TestScene2"));
        }
    }
}

