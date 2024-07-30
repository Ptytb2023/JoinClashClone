using GameStates.GameStateMachine;
using GameStates.States;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    [RequireComponent(typeof(Button))]
    public class ContinueButton : MonoBehaviour
    {
        [SerializeField] private GameObject _pausePanel;

        private Button _button;
        private IGameStateMachine _gameStateMachine;

        [Inject]
        private void Constctruc(IGameStateMachine gameStateMachine) =>
            _gameStateMachine = gameStateMachine;

        private void Awake() =>
            _button = GetComponent<Button>();

        private void OnEnable() =>
            _button.onClick.AddListener(OnButtonClick);

        private void OnDisable() =>
            _button.onClick.RemoveListener(OnButtonClick);

        private void OnButtonClick()
        {
            _pausePanel.SetActive(false);
            _gameStateMachine.Enter<GameplayState>();
        }
    }

}