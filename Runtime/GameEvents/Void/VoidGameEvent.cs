using System;
using UnityEngine;

namespace Codetox.GameEvents
{
    [CreateAssetMenu(menuName = Framework.MenuRoot.GameEvents.Void, fileName = nameof(VoidGameEvent), order = -100)]
    public sealed class VoidGameEvent : CustomScriptableObject
    {
        private event Action OnEventRaised;

        public void Invoke()
        {
            OnEventRaised?.Invoke();
        }

        public void AddListener(Action handler)
        {
            OnEventRaised += handler;
        }

        public void RemoveListener(Action handler)
        {
            OnEventRaised -= handler;
        }
    }
}