using GameStates.GameStateMachine;
using GameStates.States;
using Input.Touches;
using UnityEngine;
using Zenject;

namespace Menu
{
    public class GameStartLisener : MonoBehaviour
    {
        [SerializeField] private InputTouchPanel _input;


        private IGameStateMachine _gameStateMachine;

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        private void OnEnable()
        {
            _input.Begun += stx => EnterGamplayState();
        }

        private void OnDisable()
        {
            _input.Begun -= stx => EnterGamplayState();
        }

        private void EnterGamplayState()
        {
            _gameStateMachine.Enter<GameplayState>();
        }
    }
}
