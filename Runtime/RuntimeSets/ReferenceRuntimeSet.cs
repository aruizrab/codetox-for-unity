using UnityEngine;

namespace Codetox.RuntimeSets
{
    [CreateAssetMenu(menuName = Framework.MenuRoot.RuntimeSets.Reference, fileName = nameof(ReferenceRuntimeSet), order = 12)]
    public sealed class ReferenceRuntimeSet : RuntimeSet<Object>
    {
    }
}