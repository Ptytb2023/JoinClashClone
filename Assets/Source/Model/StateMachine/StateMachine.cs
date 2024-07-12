using Model.Messaging;
using Model.StateMachine.States;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.StateMachine
{
    public class StateMachine : ITickable
    {
        private Dictionary<Type, BaseState> _states;

        private BaseState _currentState = new BaseState.Empty();

        private const string Name = nameof(StateMachine);

        public StateMachine(IEnumerable<BaseState> states)
        {
            _states = new Dictionary<Type, BaseState>();
            Initialize(states);
        }

        private void Initialize(IEnumerable<BaseState> states)
        {
            foreach (var (state, type) in states.Select(state => (state, state.GetType())))
            {
                if (_states.ContainsKey(type))
                    throw new InvalidOperationException
                        ($"{Name} allredy contains {nameof(type.FullName)} state");
                _states.Add(type, state);
            }
        }

        public void Enter<TState>() where TState : BaseState
        {
            Type stateType = typeof(TState);

            if (_states.ContainsKey(stateType) == false)
                throw new InvalidOperationException($"{Name} is allredy in this state");

            if (_states.TryGetValue(stateType, out BaseState state) == false)
                throw new InvalidOperationException($"{stateType} is not registered in {Name}");

            ChangeState(state);
        }

        private void ChangeState(BaseState state)
        {
            _currentState.Exit();
            _currentState = state;
            _currentState.Enter();
        }

        public void Tick(float deltaTime) => 
            _currentState.Tick(deltaTime);
    }
}
