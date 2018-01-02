using System.Collections;
using UnityEngine;

namespace MUnityLibrary.OutGame
{
    public abstract class ScreenPresenterBase : MonoBehaviour
    {
        private readonly ScreenModelBase _model = new ScreenModelBase();

        public string ScreenName => _model.ScreenName;

        public virtual void Initialize()
        {
        }

        public virtual IEnumerator OnBeforeOpenScreenEnumerator()
        {
            yield break;
        }

        public virtual IEnumerator OnOpenScreenEnumerator()
        {
            yield break;
        }

        public IEnumerator OnBeforeCloseScreenEnumerator()
        {
            yield break;
        }

        public IEnumerator OnCloseScreenEnumerator()
        {
            yield break;
        }
    }
}