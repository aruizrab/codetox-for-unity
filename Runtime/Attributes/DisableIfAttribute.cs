using System;
using UnityEngine;

namespace Codetox.Attributes
{
    /// <summary>
    ///     Disables property if the specified comparison between the value of the specified field and the given value
    ///     evaluates to true.
    /// </summary>
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