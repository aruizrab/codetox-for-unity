using Codetox;
using UnityEngine;

namespace Codetox.GameEvents
{
    [CreateAssetMenu(menuName = Framework.MenuRoot.GameEvents.Int, fileName = nameof(IntGameEvent), order = -7)]
    public sealed class IntGameEvent : GameEvent<int>
    {
    }
}