using Codetox;
using UnityEngine;

namespace Codetox.GameEvents
{
    [CreateAssetMenu(menuName = Framework.MenuRoot.GameEvents.Vector2, fileName = nameof(Vector2GameEvent), order = -5)]
    public sealed class Vector2GameEvent : GameEvent<Vector2>
    {
    }
}