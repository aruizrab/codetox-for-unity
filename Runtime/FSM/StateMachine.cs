using UnityEngine;

namespace Codetox.FSM
{
    public abstract class StateMachine<T> : MonoBehaviour where T : StateMachine<T>
    {
        protected State<T> CurrentState;

        private void Awake()
        {
            Init();
        }

        private void Start()
        {
            SetState(GetInitialState());
        }

        private void Update()
        {
            CurrentState?.LogicUpdate(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            CurrentState?.PhysicsUpdate(Time.fixedDeltaTime);
        }

        public void SetState(State<T> nextState)
        {
            if (CurrentState?.Equals(nextState) ?? false) return;
            
            var previousState = CurrentState;

            CurrentState?.Exit(nextState);
            CurrentState = nextState;
            CurrentState?.Enter(previousState);
        }

        protected abstract void Init();
        protected abstract State<T> GetInitialState();
    }
}