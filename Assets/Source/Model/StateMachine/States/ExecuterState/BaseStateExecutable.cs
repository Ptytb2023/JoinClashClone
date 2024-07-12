using Model.StateMachine.States;

namespace StateMachine.States.ExecuterState
{
    public abstract class BaseStateExecutable : BaseState
    {
        private StateExecutorData _stateStructure;

        public BaseStateExecutable(StateExecutorData stateStructure)
        {
            _stateStructure = stateStructure;
        }

        public override void Enter()
        {
            _stateStructure.Enter();
            EnterState();
        }

        public override void Exit()
        {
            _stateStructure.Exit();
            ExitState();
        }

        public abstract void EnterState();
        public abstract void ExitState();

    }
}
