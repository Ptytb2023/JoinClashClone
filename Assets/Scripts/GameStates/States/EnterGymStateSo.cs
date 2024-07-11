using UnityEngine;

using GameStates.Base;
using SceneLoading;

namespace GameStates.States
{
    [CreateAssetMenu(fileName = nameof(EnterGymStateSo),
        menuName = nameof(ScriptableObject) + GameStatesStructure.Namespace + nameof(EnterGymStateSo),
        order = 51)]
    public class EnterGymStateSo : BaseGameStateSo
    {
        [SerializeField] private Scene _gymScene;

        private IAsyncSceneLoading _asyncSceneLoading = new AddressablesSceneLoading();

        public override void Enter() => 
            _asyncSceneLoading.LoadAsync(_gymScene);

        public override void Exit() => 
            _asyncSceneLoading.UnloadAsync(_gymScene);
    }
}
