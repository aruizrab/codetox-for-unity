using UnityEngine;

namespace Codetox.RuntimeSets
{
    [CreateAssetMenu(menuName = Framework.MenuRoot.RuntimeSets.Vector2, fileName = nameof(Vector2RuntimeSet), order = -5)]
    public sealed class Vector2RuntimeSet : RuntimeSet<Vector2>
    {
    }
}