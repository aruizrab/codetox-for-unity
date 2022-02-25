using System;
using UnityEngine;

namespace Codetox.Attributes
{
    /// <summary>
    /// Disables property, making it visible in the inspector but not editable.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class DisabledAttribute : PropertyAttribute
    {
    }
}