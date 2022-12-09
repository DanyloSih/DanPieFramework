using System;
using UnityEngine;

namespace DanPie.Framework.Common
{
    public abstract class ActivableObject : MonoBehaviour, IActivable
    {
        public bool IsActive { get; private set; }

        private bool _isActivating = false;
        private bool _isDeactivating = false;

        public void Activate()
        {
            if (_isActivating)
            {
                return;
            }
            _isActivating = true;
            OnActivating();
            IsActive = true;
            _isActivating = false;
        }

        public void Deactivate()
        {
            if (_isDeactivating)
            {
                return;
            }
            _isDeactivating = true;
            OnDeactivating();
            IsActive = false;
            _isDeactivating = false;
        }

        protected abstract void OnActivating();
        protected abstract void OnDeactivating();
    }
}
