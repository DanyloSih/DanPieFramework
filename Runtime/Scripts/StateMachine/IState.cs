using System;

namespace DanPie.Framework.StateMachine
{
    public interface IState
    {
        public event Action<IState> OnTransited;

        public void Enter();
    }
}
