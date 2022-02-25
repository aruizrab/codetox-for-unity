using System;
using UnityEngine;

namespace Codetox.Attributes
{
    /// <summary>
    ///     Disables property if the value of the specified field matches any of the given values.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class DisableIfMatchAttribute : PropertyAttribute
    {
        public readonly string Name;
        public readonly object[] Values;

        public DisableIfMatchAttribute(string name, params object[] values)
        {
            Name = name;
            Values = values;
        }
    }
}