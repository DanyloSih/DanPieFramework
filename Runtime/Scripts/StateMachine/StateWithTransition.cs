using System;
using System.Collections.Generic;
using UnityEngine;

namespace DanPie.Framework.StateMachine
{
    public abstract class StateWithTransition : MonoBehaviour, IState
    {
        [SerializeField] private List<Transition> _transitions;

        public event Action<IState> OnTransited;

        public void Enter()
        {
            foreach (Transition transition in _transitions)
            {
                transition.OnTransited += SetNextState;
                transition.Enter();
            }
            OnEnter();
        }

        public void Exit()
        {
            foreach (Transition transition in _transitions)
            {
                transition.OnTransited -= SetNextState;
            }
            OnExit();
        }

        protected abstract void OnEnter();

        protected abstract void OnExit();

        private void SetNextState(IState state) => OnTransited?.Invoke(state);
    }
}
