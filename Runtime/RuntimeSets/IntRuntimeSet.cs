using UnityEngine;

namespace Codetox.RuntimeSets
{
    [CreateAssetMenu(menuName = Framework.MenuRoot.RuntimeSets.Int, fileName = nameof(IntRuntimeSet), order = -7)]
    public sealed class IntRuntimeSet : RuntimeSet<int>
    {
    }
}