using System.Collections.Generic;
using System.Linq;
using Model.Sources.Model.Movement;
using UnityEngine;

namespace Model.Stickmen
{
	public class StickmanHordeMovement : IMovementStatsProvider
	{
		[System.Serializable]
		public struct Preferences
		{
			public float MaxSpeed;
			public float AccelerationTime;
		}

		private readonly StickmanHorde _horde;
		private readonly Preferences _preferences;
		private readonly InertialMovement _inertialMovement;
		private readonly List<StickmanMovement> _stickmanMovements;


		public StickmanHordeMovement(StickmanHorde horde, Preferences preferences)
		{
			_horde = horde;
			_preferences = preferences;

			_inertialMovement = new InertialMovement(this);

			_stickmanMovements = _horde.Stickmans.ToList();
		}

		public void OnEnable()
		{
			_horde.Added += OnStickmanAdded;
			_horde.Removed += OnStickmanRemoved;
		}

		public void OnDisable()
		{
			_horde.Added -= OnStickmanAdded;
			_horde.Removed -= OnStickmanRemoved;
		}

		public StickmanHordeMovement Initialize()
		{
			foreach (StickmanMovement stickman in _stickmanMovements)
				stickman.Bind(_inertialMovement);

			return this;
		}

		public MovementStats Stats() =>
			new MovementStats(_preferences.MaxSpeed, _preferences.AccelerationTime);

		public void Bind(IMovementStatsProvider provider) =>
			_inertialMovement.Bind(provider);

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


		public void MoveRight(float axis)
		{
			foreach (StickmanMovement stickman in _stickmanMovements)
			{
				if (CanMove(axis))
					stickman.MoveRight(axis, Time.deltaTime);
			}
		}

		public void RemoveStickman(StickmanMovement stickmanMovement) =>
			_stickmanMovements.Remove(stickmanMovement);

		private bool CanMove(float axis) =>
			_stickmanMovements.Any(x => x.OnRightBound && axis > 0.0f ||
			                            x.OnLeftBound && axis < 0.0f) == false;

		private void OnStickmanAdded(StickmanMovement stickman)
		{
			_stickmanMovements.Add(stickman);
			stickman.Bind(_inertialMovement);
		}

		private void OnStickmanRemoved(StickmanMovement stickman) =>
			RemoveStickman(stickman);
	}
}