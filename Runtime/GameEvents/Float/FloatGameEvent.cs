using Codetox;
using UnityEngine;

namespace Codetox.GameEvents
{
    [CreateAssetMenu(menuName = Framework.MenuRoot.GameEvents.Float, fileName = nameof(FloatGameEvent), order = -8)]
    public sealed class FloatGameEvent : GameEvent<float>
    {
    }
}