using UnityEngine;

namespace Codetox.RuntimeSets
{
    [CreateAssetMenu(menuName = Framework.MenuRoot.RuntimeSets.Float, fileName = nameof(FloatRuntimeSet), order = -8)]
    public class FloatRuntimeSet : RuntimeSet<float>
    {
    }
}