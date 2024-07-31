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

        public async void Enter()
        {
            await _sceneLoading.LoadAsync(_level);
            await _sceneLoading.LoadAsync(_menu);
        }

        public void Exit()
        {
        }
    }
}
