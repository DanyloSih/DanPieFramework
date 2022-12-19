using DanPie.Framework.Coroutines;
using UnityEngine;

namespace DanPie.Framework.StateMachine.Transitions
{
    public class WaitForSecondsTransition : Transition
    {
        [SerializeField] private StateWithTransition _nextState;
        [SerializeField] private float _waitSeconds = 3f;

        public override void Enter()
        {
            StartCoroutine(
                CoroutineUtilities.WaitForSeconds(_waitSeconds, () => ThrowNextState(_nextState)));      
        }
    }
}
