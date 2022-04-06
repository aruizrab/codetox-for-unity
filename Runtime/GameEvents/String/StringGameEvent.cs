using Codetox;
using UnityEngine;

namespace Codetox.GameEvents
{
    [CreateAssetMenu(menuName = Framework.MenuRoot.GameEvents.String, fileName = nameof(StringGameEvent), order = -6)]
    public sealed class StringGameEvent : GameEvent<string>
    {
    }
}