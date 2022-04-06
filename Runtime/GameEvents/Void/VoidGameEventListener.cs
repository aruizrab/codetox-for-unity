using Codetox;
using UnityEngine;
using UnityEngine.Events;

namespace Codetox.GameEvents
{
    [AddComponentMenu(Framework.MenuRoot.GameEventListeners.Void, -100)]
    public sealed class VoidGameEventListener : MonoBehaviour
    {
        [SerializeField] private VoidGameEvent gameEvent;
        [SerializeField] private UnityEvent unityEventResponse;

        private void OnEnable()
        {
            if (gameEvent == null) return;
            gameEvent.AddListener(OnEventRaised);
        }

        private void OnDisable()
        {
            if (gameEvent == null) return;
            gameEvent.RemoveListener(OnEventRaised);
        }

        private void OnEventRaised()
        {
            unityEventResponse?.Invoke();
        }
    }
}