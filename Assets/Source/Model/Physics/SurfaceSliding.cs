using Model.Messaging;
using UnityEngine;

namespace Model.Physics
{
    public class SurfaceSliding : IColidable
    {
        private Vector3 _surfaceNormal;
        public bool IsGrounded { get; private set; }

        public Vector3 DirectionAlongSurface(Vector3 originalDirection) =>
            Vector3.ProjectOnPlane(originalDirection, _surfaceNormal);

        public void OnCollisionEnter(Collision collision)
        {
            _surfaceNormal = collision.contacts[0].normal;
            IsGrounded = false;
        }

        public void OnCollisionExit(Collision collision) =>
            IsGrounded = true;

        public void OnCollisionStay(Collision collision) { }
    }
}
