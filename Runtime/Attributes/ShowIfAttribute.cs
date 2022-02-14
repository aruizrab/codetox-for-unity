using System;
using UnityEngine;

namespace Codetox.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class ShowIfAttribute : PropertyAttribute
    {
        public ShowIfAttribute(string comparedPropertyName, object comparedValue)
        {
            this.comparedPropertyName = comparedPropertyName;
            this.comparedValue = comparedValue;
        }

        public string comparedPropertyName { get; }
        public object comparedValue { get; }
    }
}