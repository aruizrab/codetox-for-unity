using Codetox;
using UnityEngine;

namespace Codetox.GameEvents
{
    [CreateAssetMenu(menuName = Framework.MenuRoot.GameEvents.Reference, fileName = nameof(ReferenceGameEvent), order = 12)]
    public sealed class ReferenceGameEvent : GameEvent<Object>
    {
    }
}