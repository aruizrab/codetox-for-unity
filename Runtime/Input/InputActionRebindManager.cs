using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

namespace Codetox.Input
{
    [CreateAssetMenu(menuName = Framework.MenuRoot.Input.ActionRebind.Path,
        fileName = nameof(InputActionRebindManager))]
    public sealed class InputActionRebindManager : CustomScriptableObject
    {
        [SerializeField] private InputActionReference inputActionReference;
        [SerializeField] private InputAction excludeBindings;
        [SerializeField] private InputAction cancelBindings;

        private InputDevice _currentDevice;
        private InputControlScheme _currentScheme;

        private void OnEnable()
        {
            if (!inputActionReference) return;
            InputSystem.onEvent += OnInputSystemEvent;
        }

        private void OnDisable()
        {
            if (!inputActionReference) return;
            InputSystem.onEvent -= OnInputSystemEvent;
        }

        public void StartRebind()
        {
            if (!inputActionReference) return;

            var inputAction = inputActionReference.action;
            var bindingIndex = inputAction.GetBindingIndex(_currentScheme.bindingGroup);

            inputAction.Disable();

            var rebindingOperation = inputAction.PerformInteractiveRebinding(bindingIndex)
                .WithBindingGroup(_currentScheme.bindingGroup).OnMatchWaitForAnother(0.1f).OnComplete(operation =>
                {
                    inputAction.Enable();
                    operation.Dispose();
                }).OnCancel(operation =>
                {
                    inputAction.Enable();
                    operation.Dispose();
                });

            rebindingOperation = excludeBindings.bindings.Aggregate(rebindingOperation,
                (current, binding) => current.WithControlsExcluding(binding.path));
            rebindingOperation = cancelBindings.bindings.Aggregate(rebindingOperation,
                (current, binding) => current.WithCancelingThrough(binding.path));

            rebindingOperation.Start();
        }

        public void ResetRebinds()
        {
            if (!inputActionReference) return;
            inputActionReference.action.RemoveAllBindingOverrides();
        }

        private void OnInputSystemEvent(InputEventPtr eventPtr, InputDevice device)
        {
            if (_currentDevice != null && _currentDevice == device) return;
            if (eventPtr.type == StateEvent.Type)
                if (!eventPtr.EnumerateChangedControls(device, 0.001f).Any())
                    return;

            _currentDevice = device;
            _currentScheme =
                inputActionReference.asset.controlSchemes.First(scheme => scheme.SupportsDevice(_currentDevice));
        }
    }
}