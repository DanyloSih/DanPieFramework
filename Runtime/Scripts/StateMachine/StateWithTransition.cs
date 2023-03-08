using System;
using System.Collections.Generic;
using DanPie.Framework.StateMachine.Transitions;
using UnityEngine;

namespace DanPie.Framework.StateMachine
{
    public abstract class StateWithTransition : MonoBehaviour, IState
    {
        [SerializeField] private List<Transition> _transitions;

        public bool IsTransited { get; private set; } = true;

        public event Action<IState> OnTransited;

        public void Enter()
        {
            IsTransited = false;

            foreach (Transition transition in _transitions)
            {
                transition.OnTransited += Exit;
                transition.Enter();
            }
            OnEnter();
        }

        public void Exit(IState state)
        {
            IsTransited = true;
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
