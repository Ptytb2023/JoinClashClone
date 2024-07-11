using GameStates.Interface;

namespace GameStates.GameStateMachine
{
	public interface IGameStateMachine
	{
		void Enter<TState>() where TState : IGameState;
	}
}