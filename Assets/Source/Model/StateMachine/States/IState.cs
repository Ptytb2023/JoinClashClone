
using Model.Messaging;

namespace StateMachine.States
{
    public interface IState
    {
        public void Enter();
        public void Exit();
    }
}
