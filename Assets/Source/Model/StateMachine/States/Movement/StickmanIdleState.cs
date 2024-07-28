using Model.StateMachine;
using Model.Stickmans;
using StateMachine.States.Group;
using UnityEngine;

namespace StateMachine.States.Movement
{
    public class StickmanIdleState : StickmanMoveStatesGroup
    {
        public StickmanIdleState(StickmanMovement movement, Animator animator, int animationHash)
            : base(movement, animator, animationHash) { }

        public override void CheckTransitions(StickmanStateMachine stateMachine)
        {
            if (IsRunning)
                stateMachine.Enter<StickmanRunState>();
        }
    }
}