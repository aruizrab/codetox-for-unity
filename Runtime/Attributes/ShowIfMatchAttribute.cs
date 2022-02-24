using System;
using UnityEngine;

namespace Codetox.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class ShowIfMatchAttribute: PropertyAttribute
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