using GameStates.Interface;
using SceneLoading;

namespace GameStates.States
{
    public class EnterLevelState : IGameState
    {
        private Scene _gymScene;
        private IAsyncSceneLoading _asyncSceneLoading;

        public EnterLevelState(Scene gymScene, IAsyncSceneLoading asyncSceneLoading)
        {
            _gymScene = gymScene;
            _asyncSceneLoading = asyncSceneLoading;
        }

        public void Enter() =>
            _asyncSceneLoading.LoadAsync(_gymScene);

        public void Exit() =>
            _asyncSceneLoading.UnloadAsync(_gymScene);
    }
}
