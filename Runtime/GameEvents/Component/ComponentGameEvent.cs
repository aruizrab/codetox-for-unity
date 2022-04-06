using Codetox;
using UnityEngine;

namespace Codetox.GameEvents
{
    [CreateAssetMenu(menuName = Framework.MenuRoot.GameEvents.Component, fileName = nameof(ComponentGameEvent), order = 11)]
    public sealed class ComponentGameEvent : GameEvent<Component>
    {
    }
}