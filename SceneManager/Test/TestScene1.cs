using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Masa.Scene;

namespace Masa.Scene.Test
{
    public class TestScene1 : SceneBase
    {
        public override IEnumerator OnMoveIn()
        {
            Debug.LogError("Test");
            yield return null;
        }

        public override IEnumerator OnMoveOut()
        {
            Debug.LogError("NiveOut");
            yield return null;
        }
    }
}
