using Codetox.GameEvents;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Codetox.Input.InputActionHandlers
{
    [CreateAssetMenu(menuName = Framework.MenuRoot.Input.ActionHandlers.Void, fileName = nameof(VoidInputActionHandler), order = -20)]
    public sealed class VoidInputActionHandler : CustomScriptableObject
    {
        [SerializeField] private InputActionReference inputActionReference;
        [SerializeField] private VoidGameEvent onActionStartedEvent;
        [SerializeField] private VoidGameEvent onActionPerformedEvent;
        [SerializeField] private VoidGameEvent onActionCanceledEvent;

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

        private void OnActionStarted(InputAction.CallbackContext ctx)
        {
            if (onActionStartedEvent) onActionStartedEvent.Invoke();
        }

        private void OnActionPerformed(InputAction.CallbackContext ctx)
        {
            if (onActionPerformedEvent) onActionPerformedEvent.Invoke();
        }

        private void OnActionCanceled(InputAction.CallbackContext ctx)
        {
            if (onActionCanceledEvent) onActionCanceledEvent.Invoke();
        }
    }
}