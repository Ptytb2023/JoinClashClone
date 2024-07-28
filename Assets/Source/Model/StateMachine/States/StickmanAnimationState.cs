using Model.StateMachine.States;
using UnityEngine;

namespace StateMachine.States
{
    public class StickmanAnimationState : StickmanState
    {
        protected readonly Animator Animator;
        protected readonly int AnimationHash;

        public StickmanAnimationState(Animator animator, int animationHash)
        {
            Animator = animator;
            AnimationHash = animationHash;
        }
    }
}
