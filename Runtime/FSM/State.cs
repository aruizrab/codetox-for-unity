namespace Codetox.FSM
{
    public abstract class State<T> where T : StateMachine<T>
    {
        protected readonly T StateMachine;

        protected State(T stateMachine)
        {
            StateMachine = stateMachine;
        }

        public virtual void Enter(State<T> previousState)
        {
        }

        public virtual void LogicUpdate(float dt)
        {
        }

        public virtual void PhysicsUpdate(float dt)
        {
        }

        public virtual void Exit(State<T> nextState)
        {
        }
    }
}