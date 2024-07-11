using GameStates.Base;
using UnityEngine;

namespace GameStates.GameStateMachine
{
    [CreateAssetMenu(fileName = nameof(GameStateMachineSo),
        menuName = nameof(ScriptableObject) + GameStatesStructure.Namespace + nameof(GameStateMachineSo),
        order = 51)]
    public class GameStateMachineSo : ScriptableObject, IGameStateMachine
    {
        [SerializeField] private BaseGameStateSo[] _states;

        private GameStateMachine _stateMachine;

        private void OnEnable() =>
            _stateMachine = new GameStateMachine(_states);

        public void Enter<TState>() where TState : IGameState =>
            _stateMachine.Enter<TState>();
    }
}