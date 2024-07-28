using Model.Physics;
using System;
using UnityEngine;

namespace Model.Stickmans
{
    public class StickmanMovement
    {
        public readonly Stickman Model;

        private readonly SurfaceSliding _surfaceSliding;
        private readonly InertialMovement _inertialMovement;
        private readonly float _distanceBetweenBounds;

        private Vector3 _startMovePosition;

        public StickmanMovement(Stickman model, SurfaceSliding surfaceSliding, InertialMovement inertialMovement, float distanceBetweenBounds)
        {
            Model = model;
            _surfaceSliding = surfaceSliding;
            _inertialMovement = inertialMovement;
            _distanceBetweenBounds = distanceBetweenBounds;
        }

        public bool OnRightBound => Math.Abs(Model.Position.x - DistanceToBound) < 0.1f;
        public bool OnLeftBound => Math.Abs(Model.Position.x - -DistanceToBound) < 0.1f;
        public float Acceleration => _inertialMovement.Acceleration;

        private float DistanceToBound => _distanceBetweenBounds / 2.0f;

        public void UpdateMovingRight() =>
            _startMovePosition = Model.Position;

        public void MoveRight(float axis)
        {
            Vector3 position = Model.Position;

            position.x = _distanceBetweenBounds * axis + _startMovePosition.x;
            position.x = Mathf.Clamp(position.x, -DistanceToBound, DistanceToBound);

            Model.Move(position);
        }

        public void Accelerate(float deltaTime)
        {
            _inertialMovement.Accelerate(deltaTime);

            MoveForward(deltaTime);
        }

        public void Slowdown(float deltaTime)
        {
            _inertialMovement.Slowdown(deltaTime);

            MoveForward(deltaTime);
        }

        private void MoveForward(float deltaTime)
        {
            Vector3 directionAlongSurface = _surfaceSliding.DirectionAlongSurface(Model.Forward);
            Vector3 delta = directionAlongSurface * (_inertialMovement.Acceleration * deltaTime);

            Model.Move(Model.Position + delta);
        }
    }
}
