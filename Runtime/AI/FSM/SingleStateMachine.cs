using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Codetox.AI.FSM
{
    public class SingleStateMachine
    {
        public static readonly string DefaultStateName = "Default";

        private readonly Dictionary<string, IState> _states;

        private IState _currentState;

        public SingleStateMachine([NotNull] IState defaultState, Dictionary<string, IState> states = null)
        {
            _states = states ?? new Dictionary<string, IState>();
            AddState(DefaultStateName, defaultState);
            SetState(DefaultStateName);
        }

        public void AddState([NotNull] string name, [NotNull] IState state)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            _states[name] = state ?? throw new ArgumentNullException(nameof(state));
        }

        public void RemoveState(string name)
        {
            if (!_states.ContainsKey(name)) return;
            _states.Remove(name);
        }

        public void SetState(string name)
        {
            var next = _states.ContainsKey(name) ? _states[name] : _states[DefaultStateName];
            _currentState.Exit();
            _currentState = next;
            _currentState.Enter();
        }

        public void LogicUpdate(float dt)
        {
            _currentState.LogicUpdate(dt);
        }

        public void PhysicsUpdate(float dt)
        {
            _currentState.PhysicsUpdate(dt);
        }
    }
}