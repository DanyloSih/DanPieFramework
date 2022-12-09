namespace DanPie.Framework.StateMachine
{
    public interface IStateMachine
    {
        public IState CurrentState {  get; }

        public void SetState(IState state);
    }
}
