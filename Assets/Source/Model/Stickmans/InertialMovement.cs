﻿using UnityEngine;

namespace Model.Stickmans
{
    public class InertialMovement
    {
        private readonly float _accelerationTime;
        private readonly float _maxSpeed;

        public InertialMovement(float accelerationTime, float maxSpeed)
        {
            _accelerationTime = accelerationTime;
            _maxSpeed = maxSpeed;
        }

        public float Acceleration { get; private set; }

        public void Accelerate(float deltaTime)
        {
            Acceleration += _maxSpeed * (deltaTime / _accelerationTime);
            Acceleration = Mathf.Clamp(Acceleration, 0.0f, _maxSpeed);
        }

        public void Slowdown(float deltaTime) => 
            Acceleration -= Acceleration * (deltaTime / _accelerationTime);
    }
}
