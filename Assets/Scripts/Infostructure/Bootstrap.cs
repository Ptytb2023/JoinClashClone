using UnityEngine;

using GameStates.States;
using GameStates.GameStateMachine;

namespace Infostructure
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private GameStateMachineSo _gameStateMachine;

        private void OnEnable()
        {
            _gameStateMachine.Enter<EnterGymStateSo>();
        }
    }
}
