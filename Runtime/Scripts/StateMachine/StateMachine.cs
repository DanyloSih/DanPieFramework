namespace DanPie.Framework.StateMachine
{
    public abstract class StateMachine<T> : IStateMachine<T>
        where T : IState
    {
        private T _currentState;

        public T CurrentState { get => _currentState; }

        public void SetState(IState state)
        {
            if (_currentState != null && !_currentState.IsTransited)
            {
                _currentState.Exit(state);
            }

            SetTState((T)state);
        }

        protected void StartStateMachine(T initialState)
        {
            _currentState = initialState;
            _currentState.OnTransited += SetState;
            _currentState.Enter();
        }

        protected virtual void OnStateEnter(T state) { }

        private void SetTState(T state)
        {
            _currentState.OnTransited -= SetState;
            _currentState = state;
            _currentState.OnTransited += SetState;
            _currentState.Enter();
            OnStateEnter(state);
        }
    }
}
