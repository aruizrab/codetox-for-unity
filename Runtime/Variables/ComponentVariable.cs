using Codetox;
using UnityEngine;

namespace Codetox.Variables
{
    [CreateAssetMenu(menuName = Framework.MenuRoot.Variables.Component, fileName = nameof(ComponentVariable), order = 11)]
    public sealed class ComponentVariable : Variable<Component>
    {
    }
}