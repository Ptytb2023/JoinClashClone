using GameStates.Interface;
using SceneLoading;

using Scene = SceneLoading.Scene;

namespace GameStates.States
{
    public class BootstarpState : IGameState
    {
        private Scene _level;
        private Scene _menu;

        private IAsyncSceneLoading _sceneLoading;

        public BootstarpState(Scene level, Scene menu, IAsyncSceneLoading sceneLoading)
        {
            _level = level;
            _menu = menu;
            _sceneLoading = sceneLoading;
        }

        public void Enter()
        {
            _sceneLoading.LoadAsync(_level);
            _sceneLoading.LoadAsync(_menu);
        }

        public void Exit()
        {
        }
    }
}
