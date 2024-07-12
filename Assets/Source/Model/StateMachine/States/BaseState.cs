using StateMachine.States;


namespace Model.StateMachine.States
{
    public abstract class BaseState : IState
    {
        public abstract void Enter();

        public abstract void Exit();

        public abstract void Tick(float deltaTime);


        internal class Empty : BaseState
        {
            public override void Enter() { }

            public override void Exit() { }

            public override void Tick(float deltaTime) { }
        }
    }
}
