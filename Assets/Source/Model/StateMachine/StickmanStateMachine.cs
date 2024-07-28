using Model.Messaging;
using Model.StateMachine.States;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.StateMachine
{
    public class StickmanStateMachine : ITickable
    {
        private Dictionary<Type, StickmanState> _states;
        private StickmanState _currentState = new StickmanState.Empty();

        public StickmanStateMachine(IEnumerable<StickmanState> states)
        {
            _states = new Dictionary<Type, StickmanState>();
            Initialize(states);
        }

        public void Enter<TState>() where TState : StickmanState
        {
            Type stateType = typeof(TState);

            if (_states.TryGetValue(stateType, out StickmanState state) == false)
                throw new InvalidOperationException($"{stateType} is not registered in {stateType}");

            if (_currentState == state)
                throw new ArgumentOutOfRangeException($"{state} allredy is enabel");

            ChangeState(state);
        }

        public void Tick(float deltaTime)
        {
            _currentState.Tick(deltaTime);

            CheckTransitions();
        }

        private void CheckTransitions() =>
           _currentState.CheckTransitions(this);

        private void ChangeState(StickmanState state)
        {
            _currentState.Exit();
            _currentState = state;
            _currentState.Enter();
        }

        private void Initialize(IEnumerable<StickmanState> states)
        {
            foreach (var (state, type) in states.Select(state => (state, state.GetType())))
            {
                if (_states.ContainsKey(type))
                    throw new InvalidOperationException
                        ($"{type} allredy contains {nameof(type.FullName)} state");

                _states.Add(type, state);
            }
        }
    }
}
