using System;
using UnityEngine;

namespace Codetox.Variables
{
    // TODO [$624dc2494a024b0008cb367c]: Add documentation to Variable.cs
    public abstract class Variable<T> : CustomScriptableObject
    {
        [SerializeField] private T value;

        [SerializeField]
        [Tooltip("Prevent the value of this variable from being modified at runtime by other scripts.")]
        private bool readOnly;

        public T Value
        {
            get => value;
            set
            {
                if (readOnly) return;
                if (this.value.Equals(value)) return;
                this.value = value;
                OnValueChanged?.Invoke(value);
            }
        }

        private void Reset()
        {
            Value = default;
        }

        private void OnEnable()
        {
            Value = value;
        }

        public event Action<T> OnValueChanged;
    }
}