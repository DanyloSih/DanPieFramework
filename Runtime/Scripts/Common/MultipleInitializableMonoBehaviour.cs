using UnityEngine;

namespace DanPie.Framework.Common
{

    public abstract class MultipleInitializableMonoBehaviour : MonoBehaviour
    {
        public bool IsInitialized { get; protected set; } = false;

        protected void CheckIsInitialized()
        {
            if (!IsInitialized)
            {
                throw new NonInitializedException();
            }
        }
    }
}