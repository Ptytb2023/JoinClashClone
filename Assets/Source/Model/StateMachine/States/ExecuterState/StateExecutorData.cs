using System;

namespace StateMachine.States.ExecuterState
{
    public class StateExecutorData : IState
    {
        private Action _enterAction;
        private Action _exitAction;

        public StateExecutorData(Action enterAction) =>
            _enterAction = enterAction ??
                throw new NullReferenceException($"{nameof(enterAction)} should be not null");

        public StateExecutorData(Action enterAction, Action exitAction) : this(enterAction) =>
            _exitAction = exitAction ??
                throw new NullReferenceException($"{nameof(exitAction)} should be not null");

        public void Enter() =>
            _enterAction?.Invoke();

        public void Exit() =>
            _exitAction?.Invoke();

    }
}
