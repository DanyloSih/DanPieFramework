using System;

namespace DanPie.Framework.StateMachine
{
    public interface IState
    {
        public event Action<IState> OnTransited;

        public bool IsTransited { get; }

        public void Enter();
        public void Exit(IState nextState);
    }
}
