using GameStates.Base;

namespace GameStates.GameStateMachine
{
	public interface IGameStateMachine
	{
		void Enter<TState>() where TState : IGameState;
	}
}