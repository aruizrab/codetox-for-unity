namespace Codetox.AI.FSM
{
    public interface IState
    {
        void Enter();
        void LogicUpdate(float dt);
        void PhysicsUpdate(float dt);
        void Exit();
    }
}