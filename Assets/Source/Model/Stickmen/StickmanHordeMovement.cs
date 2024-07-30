using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Stickmen
{
    public class StickmanHordeMovement : IDisposable
	{
		private readonly StickmanHorde _horde;

		public StickmanHordeMovement(StickmanHorde horde)
		{
			_horde = horde;
			_stickmanMovements = _horde.Stickmans.ToList();

			_horde.Added += OnStickmanAdded;
			_horde.Removed += OnStikcmanRemoved;
		}

		private List<StickmanMovement> _stickmanMovements;

        public void Accelerate(float deltaTime)
		{
			foreach (StickmanMovement stickman in _stickmanMovements)
				stickman.Accelerate(deltaTime);
		}

		public void Slowdown(float deltaTime)
		{
			foreach (StickmanMovement stickman in _stickmanMovements)
				stickman.Slowdown(deltaTime);
		}

		public void StartMovingRight()
		{
			foreach (StickmanMovement stickman in _stickmanMovements)
				stickman.StartMovingRight();
		}

		public void MoveRight(float axis)
		{
			if (CanMove(axis) == false)
			{
				StartMovingRight();
				return;
			}
			
			foreach (StickmanMovement stickman in _stickmanMovements)
				stickman.MoveRight(axis);
		}

        private bool CanMove(float axis) =>
            _stickmanMovements.Any(x => x.OnRightBound && axis > 0.0f 
			|| x.OnLeftBound && axis < 0.0f) == false;

		public void RemoveStickman(StickmanMovement stickmanMovement)=>
            _stickmanMovements.Remove(stickmanMovement);

        private void OnStickmanAdded(StickmanMovement stickmanMovement)=>
			_stickmanMovements.Add(stickmanMovement);

		private void OnStikcmanRemoved(StickmanMovement stickmanMovement) =>
			RemoveStickman(stickmanMovement);

        public void Dispose()
        {
            _horde.Added += OnStickmanAdded;
            _horde.Removed += OnStikcmanRemoved;
        }
    }
}