using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Masa.Scene
{
    public abstract class SceneBase : MonoBehaviour
    {
        public abstract IEnumerator OnMoveIn();

        public abstract IEnumerator OnMoveOut();
    }
}
