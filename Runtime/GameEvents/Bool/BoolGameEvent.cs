using Codetox;
using UnityEngine;

namespace Codetox.GameEvents
{
    [CreateAssetMenu(menuName = Framework.MenuRoot.GameEvents.Bool, fileName = nameof(BoolGameEvent), order = -9)]
    public sealed class BoolGameEvent : GameEvent<bool>
    {
    }
}