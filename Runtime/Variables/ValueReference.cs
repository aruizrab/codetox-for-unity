using System;
using UnityEngine;

namespace Codetox.Variables
{
    [Serializable]
    public class ValueReference<T>
    {
        [SerializeField] private bool useField;
        [SerializeField] private T fieldValue;
        [SerializeField] private Variable<T> variableValue;
        
        public T Value
        {
            get
            {
                if (!useField && variableValue) return variableValue.Value;
                return fieldValue;
            }
            set
            {
                if (!useField && variableValue) variableValue.Value = value;
                else fieldValue = value;
            }
        }
    }
}