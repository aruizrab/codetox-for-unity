using System;
using UnityEngine;

namespace Codetox.Attributes
{
    /// <summary>
    ///     Shows property if the value of the specified field matches any of the given values.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class ShowIfMatchAttribute : PropertyAttribute
    {
        public readonly string Name;
        public readonly object[] Values;

        public ShowIfMatchAttribute(string name, params object[] values)
        {
            Name = name;
            Values = values;
        }
    }
}