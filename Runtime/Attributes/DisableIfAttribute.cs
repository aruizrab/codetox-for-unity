using System;
using UnityEngine;

namespace Codetox.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class DisableIfAttribute : PropertyAttribute
    {
        public readonly ComparisonType ComparisonType;
        public readonly string Name;
        public readonly object Value;

        public DisableIfAttribute(string name, object value, ComparisonType comparisonType = ComparisonType.Equals)
        {
            Name = name;
            Value = value;
            ComparisonType = comparisonType;
        }
    }
}