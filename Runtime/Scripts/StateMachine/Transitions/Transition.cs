using System;
using UnityEngine;

namespace DanPie.Framework.StateMachine.Transitions
{
    public abstract class Transition : MonoBehaviour
    {
        public event Action<IState> OnTransited;

        public abstract void Enter();

        protected void ThrowNextState(IState state)
        {
            OnTransited?.Invoke(state);
        }
    }
}
