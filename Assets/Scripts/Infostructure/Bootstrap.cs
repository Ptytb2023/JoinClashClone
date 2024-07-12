using UnityEngine;

using GameStates.States;
using GameStates.GameStateMachine;
using Zenject;

namespace Infostructure
{
    public class Bootstrap : MonoBehaviour
    {
        private IGameStateMachine _gameStateMachine;

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine) =>
            _gameStateMachine = gameStateMachine;

        private void Start()
        {
            _gameStateMachine.Enter<BootstarpState>();
        }

    }
}