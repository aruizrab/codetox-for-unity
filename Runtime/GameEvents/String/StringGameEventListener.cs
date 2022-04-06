using Codetox;
using UnityEngine;

namespace Codetox.GameEvents
{
    [AddComponentMenu(Framework.MenuRoot.GameEventListeners.String, -6)]
    public sealed class StringGameEventListener : GameEventListener<string>
    {
    }
}