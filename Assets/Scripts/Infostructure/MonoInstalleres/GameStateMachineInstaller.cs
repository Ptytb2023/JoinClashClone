using Factories.GameStates;
using GameStates.GameStateMachine;
using SceneLoading;
using UnityEngine;
using Zenject;

namespace Infostructure.MonoInstalleres
{
    public class GameStateMachineInstaller : MonoInstaller
    {
        [SerializeField] private GameStateMachineFactory _gameStateMachineFactory;

        public override void InstallBindings()
        {
            var sceneLoading = BindSceneLoading();
            BindGameStateMachine(sceneLoading);
        }

        private void BindGameStateMachine(IAsyncSceneLoading sceneLoading)
        {
            _gameStateMachineFactory.Init(sceneLoading);
            var stateMachine = _gameStateMachineFactory.Creat();

            Container.BindInterfacesAndSelfTo<GameStateMachine>().
                FromInstance(stateMachine).AsSingle().NonLazy();
        }

        private IAsyncSceneLoading BindSceneLoading()
        {
            IAsyncSceneLoading asyncSceneLoading = new AddressablesSceneLoading();

            Container.BindInterfacesAndSelfTo<AddressablesSceneLoading>().
                FromInstance(asyncSceneLoading).AsSingle().NonLazy();

            return asyncSceneLoading;
        }
    }
}
