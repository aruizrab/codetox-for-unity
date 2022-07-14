using UnityEngine;

namespace Codetox.RuntimeSets
{
    [CreateAssetMenu(menuName = Framework.MenuRoot.RuntimeSets.GameObject, fileName = nameof(GameObjectRuntimeSet), order = 10)]
    public class GameObjectRuntimeSet : RuntimeSet<GameObject>
    {
    }
}