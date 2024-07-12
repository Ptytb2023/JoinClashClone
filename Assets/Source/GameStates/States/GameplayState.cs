using GameStates.Interface;
using SceneLoading;

namespace GameStates.States
{
    public class GameplayState : IGameState
    {
        private Scene _menu;
        private IAsyncSceneLoading _sceneLoading;

        public GameplayState(Scene menu, IAsyncSceneLoading sceneLoading)
        {
            _menu = menu;
            _sceneLoading = sceneLoading;
        }

        public void Enter()
        {
            _sceneLoading.UnloadAsync(_menu);
        }

        public void Exit()
        {
        }
    }
}
