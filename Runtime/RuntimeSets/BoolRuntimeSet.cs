using UnityEngine;

namespace Codetox.RuntimeSets
{
    [CreateAssetMenu(menuName = Framework.MenuRoot.RuntimeSets.Bool, fileName = nameof(BoolRuntimeSet), order = -9)]
    public class BoolRuntimeSet : RuntimeSet<bool>
    {
    }
}