using System.Linq;
using Codetox.Attributes;
using UnityEngine;
using UnityEngine.Events;

namespace Codetox.FSM
{
    public class StateMachineComponent : MonoBehaviour
    {
        [SerializeField] private StateComponent initialStateComponent;
        [Disabled] [SerializeField] private StateComponent currentStateComponent;
        [SerializeField] private StateComponent[] states;

        public UnityEvent onInitialize;

        private void Start()
        {
            onInitialize?.Invoke();
        }

        private void OnEnable()
        {
            foreach (var state in states.Where(state => !state.Equals(initialStateComponent))) state.gameObject.SetActive(false);
            SetState(initialStateComponent);
        }

        private void OnDisable()
        {
            if (currentStateComponent) currentStateComponent.Exit();
        }

        public void SetState(StateComponent stateComponent)
        {
            if (currentStateComponent && currentStateComponent.Equals(stateComponent)) return;
            if (currentStateComponent) currentStateComponent.Exit();
            currentStateComponent = stateComponent;
            if (currentStateComponent) currentStateComponent.Enter();
        }
    }
}