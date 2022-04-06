using UnityEngine;
using UnityEngine.Events;

namespace Codetox.GameEvents
{
    public abstract class GameEventListener<T> : MonoBehaviour
    {
        [SerializeField] private GameEvent<T> gameEvent;
        [SerializeField] private UnityEvent<T> unityEventResponse;

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

        private void OnEventRaised(T payload)
        {
            unityEventResponse?.Invoke(payload);
        }
    }
}