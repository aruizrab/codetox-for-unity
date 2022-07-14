using System;
using UnityEngine;

namespace Codetox.Variables
{
    // TODO [#24]: Add documentation to Variable.cs
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

        public event Action<T> OnValueChanged;
    }
}