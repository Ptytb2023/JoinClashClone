using UnityEngine;

namespace GameStates.Base
{
	public abstract class BaseGameStateSo : ScriptableObject, IGameState
	{
		public abstract void Enter();
		public abstract void Exit();
	}
}