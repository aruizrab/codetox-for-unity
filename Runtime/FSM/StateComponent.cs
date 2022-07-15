using UnityEngine;
using UnityEngine.Events;

namespace Codetox.FSM
{
    public sealed class StateComponent : MonoBehaviour
    {
        [SerializeField] private UnityEvent onEnterState;
        [SerializeField] private UnityEvent onExitState;

        public void Enter()
        {
            gameObject.SetActive(true);
            onEnterState?.Invoke();
        }

        public void Exit()
        {
            gameObject.SetActive(false);
            onExitState?.Invoke();
        }
    }
}