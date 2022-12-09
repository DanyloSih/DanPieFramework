using UnityEngine;

namespace DanPie.Framework.StateMachine
{
    public class StateMachine : MonoBehaviour, IStateMachine
    {
        [SerializeField] private StateWithTransition _initialGameState;

        private IState _currentState;

        public IState CurrentState { get => _currentState; }

        public void Start()
        {
            _currentState = _initialGameState;
            _currentState.OnTransited += SetState;
            _currentState.Enter();
        }

        public void SetState(IState state)
        {
            _currentState.OnTransited -= SetState;
            _currentState = state;
            _currentState.OnTransited += SetState;
            _currentState.Enter();
        }
    }
}
