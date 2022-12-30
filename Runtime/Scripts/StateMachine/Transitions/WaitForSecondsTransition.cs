using System.Collections;
using DanPie.Framework.Coroutines;
using DanPie.Framework.Pause;
using UnityEngine;

namespace DanPie.Framework.StateMachine.Transitions
{
    public class WaitForSecondsTransition : Transition, IPausable
    {
        [SerializeField] private StateWithTransition _nextState;
        [SerializeField] private float _waitSeconds = 3f;
        private bool _paused;

        public override void Enter()
        {
            StartCoroutine(GoNextState());      
        }

        public void Pause()
        {
            _paused = true;
        }

        public void Resume()
        {
            _paused = false;
        }

        private IEnumerator GoNextState()
        {
            yield return new WaitWhile(() => _paused);
            yield return new WaitForSeconds(_waitSeconds);
            yield return new WaitWhile(() => _paused);
            ThrowNextState(_nextState);
        }
    }
}
