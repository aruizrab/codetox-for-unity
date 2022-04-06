using Codetox;
using UnityEngine;

namespace Codetox.GameEvents
{
    [CreateAssetMenu(menuName = Framework.MenuRoot.GameEvents.GameObject, fileName = nameof(GameObjectGameEvent), order = 10)]
    public sealed class GameObjectGameEvent : GameEvent<GameObject>
    {
    }
}