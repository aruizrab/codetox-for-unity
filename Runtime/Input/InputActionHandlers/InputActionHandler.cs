using Codetox.GameEvents;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Codetox.Input.InputActionHandlers
{
    public abstract class InputActionHandler<T> : CustomScriptableObject where T : struct
    {
        [SerializeField] protected InputActionReference inputActionReference;
        [SerializeField] protected GameEvent<T> onActionStartedEvent;
        [SerializeField] protected GameEvent<T> onActionPerformedEvent;
        [SerializeField] protected GameEvent<T> onActionCanceledEvent;

        private void OnEnable()
        {
            if (!inputActionReference) return;

            var action = inputActionReference.action;

            action.started += OnActionStarted;
            action.performed += OnActionPerformed;
            action.canceled += OnActionCanceled;
            action.Enable();
        }

        private void OnDisable()
        {
            if (!inputActionReference) return;

            var action = inputActionReference.action;

            action.started -= OnActionStarted;
            action.performed -= OnActionPerformed;
            action.canceled -= OnActionCanceled;
            action.Disable();
        }

        protected virtual void OnActionStarted(InputAction.CallbackContext ctx)
        {
            if (onActionStartedEvent) onActionStartedEvent.Invoke(ctx.ReadValue<T>());
        }

        protected virtual void OnActionPerformed(InputAction.CallbackContext ctx)
        {
            if (onActionPerformedEvent) onActionPerformedEvent.Invoke(ctx.ReadValue<T>());
        }

        protected virtual void OnActionCanceled(InputAction.CallbackContext ctx)
        {
            if (onActionCanceledEvent) onActionCanceledEvent.Invoke(ctx.ReadValue<T>());
        }
    }
}