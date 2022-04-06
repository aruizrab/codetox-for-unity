using Codetox;
using UnityEngine;

namespace Codetox.Variables
{
    [CreateAssetMenu(menuName = Framework.MenuRoot.Variables.GameObject, fileName = nameof(GameObjectVariable), order = 10)]
    public sealed class GameObjectVariable : Variable<GameObject>
    {
    }
}