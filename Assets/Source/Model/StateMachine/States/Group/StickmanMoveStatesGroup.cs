using Model.Stickmans;
using UnityEngine;

namespace StateMachine.States.Group
{
    public class StickmanMoveStatesGroup : StickmanAnimationState
    {
        private const float AccelerationToRun = 1.0f;
        private readonly StickmanMovement _movement;

        public StickmanMoveStatesGroup(StickmanMovement movement, Animator animator, int animationHash)
            : base(animator, animationHash)
        {
            _movement = movement;
        }

        protected bool IsRunning => _movement.Acceleration >= AccelerationToRun;
    }
}   
