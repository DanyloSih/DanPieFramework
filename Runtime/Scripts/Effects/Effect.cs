using System.Collections;
using DanPie.Framework.Pause;
using UnityEngine;

namespace DanPie.Framework.Effects
{

    public class Effect : PausableObject
    {
        [SerializeField] private GameObject _effectGameObject;
        [SerializeField] private float _effectTime = 0.5f;
        [SerializeField] private bool _disableAfterTimeout = false;

        public bool IsStarted { get; private set; } = false; 

        protected override void OnStart()
        {
            base.OnStart();
            _effectGameObject.SetActive(false);
        }

        public void StartEffect()
        {
            StartCoroutine(EffectProcess());
            IsStarted = true;
        }

        private IEnumerator EffectProcess()
        {
            _effectGameObject.SetActive(true);
            yield return new PausableWaitForSeconds(_effectTime, this);
            IsStarted = false;
        }
    }
}
