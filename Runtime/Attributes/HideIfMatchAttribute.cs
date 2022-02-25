using System;
using UnityEngine;

namespace Codetox.Attributes
{
    /// <summary>
    /// Hides property if the specified field matches any of the given values.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class HideIfMatchAttribute : PropertyAttribute
    {
        public readonly string Name;
        public readonly object[] Values;
        
        public HideIfMatchAttribute(string name, params object[] values)
        {
            Name = name;
            Values = values;
        }
    }
}