﻿namespace DanPie.Framework.StateMachine
{
    public interface IStateMachine<T> 
        where T : IState
    {
        public T CurrentState { get; }

        public void SetState(IState state);
    }
}
