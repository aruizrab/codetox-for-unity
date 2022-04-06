using System;

namespace Codetox.GameEvents
{
    public abstract class GameEvent<T> : CustomScriptableObject
    {
        private event Action<T> OnEventRaised;

        public void Invoke(T payload)
        {
            OnEventRaised?.Invoke(payload);
        }

        public void AddListener(Action<T> listener)
        {
            OnEventRaised += listener;
        }

        public void RemoveListener(Action<T> listener)
        {
            OnEventRaised -= listener;
        }
    }
}