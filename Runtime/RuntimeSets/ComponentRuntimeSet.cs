using UnityEngine;

namespace Codetox.RuntimeSets
{
    [CreateAssetMenu(menuName = Framework.MenuRoot.RuntimeSets.Component, fileName = nameof(ComponentRuntimeSet), order = 11)]
    public class ComponentRuntimeSet : RuntimeSet<Component>
    {
    }
}