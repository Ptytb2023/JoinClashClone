using Model.Messaging;
using StateMachine.States;

namespace Model.StateMachine.States
{
    public abstract class StickmanState : IState, ITickable
    {
        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void Tick(float deltaTime) { }

        public virtual void CheckTransitions(StickmanStateMachine StateMachine) { }

        internal class Empty : StickmanState
        { }
    }
}
