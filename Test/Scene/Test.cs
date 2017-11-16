using Flw.Scene;
using UnityEngine;
using UnityEngine.UI;

namespace Flw.Test.Scene {
    public class Test : MonoBehaviour {
        [SerializeField]
        private Button _sceneAButton;

        private void Start () {
            _sceneAButton.onClick.AddListener (OnClickedSceneAButton);
        }

        private void OnClickedSceneAButton () {
            //SceneLoader.LoadScene(Scenes.TestB);
        }
    }
}