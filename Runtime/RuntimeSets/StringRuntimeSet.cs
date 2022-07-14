using UnityEngine;

namespace Codetox.RuntimeSets
{
    [CreateAssetMenu(menuName = Framework.MenuRoot.RuntimeSets.String, fileName = nameof(StringRuntimeSet), order = -6)]
    public sealed class StringRuntimeSet : RuntimeSet<string>
    {
    }
}