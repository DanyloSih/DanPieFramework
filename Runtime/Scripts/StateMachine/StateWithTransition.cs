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
                transition.OnTransited += Exit;
                transition.Enter();
            }
            OnEnter();
        }

        private void Exit(IState state)
        {
            foreach (Transition transition in _transitions)
            {
                transition.OnTransited -= Exit;
            }
            OnExit();
            OnTransited?.Invoke(state);
        }

        protected abstract void OnEnter();

        protected abstract void OnExit();
    }
}
