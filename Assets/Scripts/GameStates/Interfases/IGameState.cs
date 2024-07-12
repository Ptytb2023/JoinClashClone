namespace GameStates.Interface
{
	public interface IGameState
	{
		void Enter();
		void Exit();
		
		public class Empty : IGameState
		{
			public void Enter() { }
			public void Exit() { }
		}
	}
}