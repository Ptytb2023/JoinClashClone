using Model.Messaging;
using Model.Transformables;
using UnityEngine;

namespace Model.Physics
{
    public class Gravity : ITickable
    {
        private const float GravityScale = -9.81f;

        private readonly SurfaceSliding _surfaceSliding;
        private readonly Transformable _transformable;

        public Gravity(SurfaceSliding surfaceSliding, Transformable transformable)
        {
            _surfaceSliding = surfaceSliding;
            _transformable = transformable;
        }
    
        public void Tick(float deltaTime)
        {
            if (!_surfaceSliding.IsGrounded)
                return;

            ApplyGravity(deltaTime);
        }

        public void ApplyGravity(float deltaTime)
        {
            Vector3 gravity = _transformable.Position;
            gravity.y += GravityScale * deltaTime;
            _transformable.Move(gravity);
        }
    }
}
