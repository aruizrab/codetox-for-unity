using System;
using UnityEngine;

namespace Codetox.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class ShowIfAnyMatchAttribute: PropertyAttribute
    {
        public readonly string Name;
        public readonly object[] Values;

        public ShowIfAnyMatchAttribute(string name, params object[] values)
        {
            Name = name;
            Values = values;
        }
    }
}