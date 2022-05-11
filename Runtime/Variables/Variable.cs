using System;
using Codetox.GameEvents;
using UnityEngine;

namespace Codetox.Variables
{
    // TODO [#24]: Add documentation to Variable.cs
    public abstract class Variable<T> : BaseVariable
    {
        [SerializeField] private T value;

        [SerializeField]
        [Tooltip("Prevent the value of this variable from being modified at runtime by other scripts.")]
        private bool readOnly;

        public GameEvent<T> onValueChanged;

        public T Value
        {
            get => value;
            set
            {
                if (readOnly) return;
                if (this.value.Equals(value)) return;
                this.value = value;
                if (onValueChanged) onValueChanged.Invoke(value);
            }
        }

        private void OnEnable()
        {
            if (onValueChanged) onValueChanged.Invoke(value);
        }

        public override VariableData GetVariableData()
        {
            return new VariableData<T>(value);
        }

        public override void LoadVariableData(VariableData data)
        {
            var variableData = data as VariableData<T> ?? new VariableData<T>(default);
            value = variableData.value;
            if (onValueChanged) onValueChanged.Invoke(value);
        }

        [Serializable]
        private class VariableData<TV> : VariableData
        {
            public TV value;

            public VariableData(TV value)
            {
                this.value = value;
            }
        }
    }
}