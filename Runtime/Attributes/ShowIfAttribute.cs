using System;
using UnityEngine;

namespace Codetox.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class ShowIfAttribute : PropertyAttribute
    {
        public readonly ComparisonType ComparisonType;
        public readonly string Name;
        public readonly object Value;

        public ShowIfAttribute(string name, object value, ComparisonType comparisonType = ComparisonType.Equals)
        {
            Name = name;
            Value = value;
            ComparisonType = comparisonType;
        }
    }
}