using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Codetox.AI.FSM
{
    public class MultipleStateMachine
    {
        private readonly Dictionary<string, IState> _states;

        public MultipleStateMachine(Dictionary<string, IState> states = null)
        {
            _states = states ?? new Dictionary<string, IState>();
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

        public void SetState(string name, IState state)
        {
            _states.Clear();
            AddState(name, state);
        }

        public void LogicUpdate(float dt)
        {
            foreach (var keyValuePair in _states) keyValuePair.Value.LogicUpdate(dt);
        }

        public void PhysicsUpdate(float dt)
        {
            foreach (var keyValuePair in _states) keyValuePair.Value.PhysicsUpdate(dt);
        }
    }
}