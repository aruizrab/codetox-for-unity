using UnityEngine;

namespace Codetox.RuntimeSets
{
    [CreateAssetMenu(menuName = Framework.MenuRoot.RuntimeSets.Vector3, fileName = nameof(Vector3RuntimeSet), order = -4)]
    public sealed class Vector3RuntimeSet : RuntimeSet<Vector3>
    {
    }
}