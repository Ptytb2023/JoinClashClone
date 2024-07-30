using GameStates.GameStateMachine;
using GameStates.Interface;
using GameStates.States;
using SceneLoading;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using Zenject;

namespace Factories.GameStates
{
    public class GameStateMachineFactory : MonoBehaviour
    {
        [SerializeField] private Scene _levelScene;
        [SerializeField] private Scene _menu;

        private IAsyncSceneLoading _sceneLoading;
        private DiContainer _diContainer;

        public void Init(IAsyncSceneLoading sceneLoading)
        {
            _sceneLoading = sceneLoading;
        }

        public IGameStateMachine Creat() =>
            new GameStateMachine(GetStates());

        private IEnumerable<IGameState> GetStates()
        {
            return new List<IGameState>()
            {
                new EnterLevelState(_levelScene, _sceneLoading),
                new BootstarpState(_levelScene,_menu,_sceneLoading),
                new GameplayStartState(_menu,_sceneLoading),
                new GameplayState(),
                new PauseState(),
            };

        }
    }
}
