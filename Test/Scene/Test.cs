using UnityEngine;
using UnityEngine.UI;

namespace Flw.Test.Scene {
    public class Test : MonoBehaviour {
        [SerializeField] private Button _sceneAButton;

        private void Start () {
            _sceneAButton.onClick.AddListener (OnClickedSceneAButton);
        }

        private static void OnClickedSceneAButton () {
            //SceneLoader.LoadScene(Scenes.TestB);
        }
    }
}