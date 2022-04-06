using Codetox;
using UnityEngine;

namespace Codetox.GameEvents
{
    [CreateAssetMenu(menuName = Framework.MenuRoot.GameEvents.Vector3, fileName = nameof(Vector3GameEvent), order = -4)]
    public sealed class Vector3GameEvent : GameEvent<Vector3>
    {
    }
}